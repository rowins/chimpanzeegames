using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class KinectControls : MonoBehaviour
{
    public GameObject BodySourceManager;
    private BodySourceManager bodyManager;

    // Lists for previous positions in time
    private List<Kinect.CameraSpacePoint> previousLeftHandPositions = new List<Kinect.CameraSpacePoint>();
    private List<Kinect.CameraSpacePoint> previousRightHandPositions = new List<Kinect.CameraSpacePoint>();
    private List<double> previousTimesLeft = new List<double>();
    private List<double> previousTimesRight = new List<double>();
    // Sensitivity values
    public double maxCheckedTime = 0.25;
    public double minDistance = 0.4;
    public float minCheckedLean = 0.2f;
    public float crossedArmsMargin = 0.25f;
    // Scripts to call functions in
    public ThrowNewspaper leftNewspaper;
    public ThrowNewspaper rightNewspaper;
    public ControlledVelocity movementScript;
    public PlayerAnimator animationScript;
    public Escape escapeScript;

    // Update is called once per frame
    void Update()
    {
        // We create some local variables in here that we pass onto other functions.
        #region Gather Intel
        if (BodySourceManager == null)
        {
            return;
        }
        bodyManager = BodySourceManager.GetComponent<BodySourceManager>();
        if (bodyManager == null)
        {
            return;
        }
        Kinect.Body[] data = bodyManager.GetData();
        if (data == null)
        {
            return;
        }
        Kinect.CameraSpacePoint leftHandPosition = new Kinect.CameraSpacePoint();
        Kinect.CameraSpacePoint rightHandPosition = new Kinect.CameraSpacePoint();
        Kinect.PointF lean = new Kinect.PointF();
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }
            Dictionary<Kinect.JointType, Kinect.Joint> joints = body.Joints;
            if (!joints.ContainsKey(Kinect.JointType.HandLeft))
            {
                continue;
            }
            if (!joints.ContainsKey(Kinect.JointType.HandRight))
            {
                continue;
            }
            Kinect.Joint leftHand = joints[Kinect.JointType.HandLeft];
            Kinect.Joint rightHand = joints[Kinect.JointType.HandRight];
            if (leftHand.Position == rightHand.Position) // Since two hands cannot be in the same position, this serves as a good check to make sure the non-null body we have does not have all default values.
            {
                continue;
            }
            leftHandPosition = leftHand.Position;
            rightHandPosition = rightHand.Position;
            lean = body.Lean;
            break;
        }
        #endregion

        #region Actions related to Newspaper Throwing
        UpdateTimes();
        ClearTimes(previousLeftHandPositions, previousTimesLeft);
        ClearTimes(previousRightHandPositions, previousTimesRight);

        ComparePosition(leftHandPosition, true);
        ComparePosition(rightHandPosition, false);

        previousLeftHandPositions.Add(leftHandPosition);
        previousRightHandPositions.Add(rightHandPosition);
        previousTimesLeft.Add(0);
        previousTimesRight.Add(0);
        #endregion
        
        CompareLean(lean);

        CompareHands(leftHandPosition, rightHandPosition, crossedArmsMargin);
    }

    /// <summary>
    /// Updates the times in the arrays of past moments in time.
    /// </summary>
    void UpdateTimes()
    {
        double deltaTime = Time.deltaTime;
        for (int i = 0; i < previousTimesLeft.Count; i++)
        {
            previousTimesLeft[i] += deltaTime;
        }
        for (int i = 0; i < previousTimesRight.Count; i++)
        {
            previousTimesRight[i] += deltaTime;
        }
    }

    /// <summary>
    /// Clears positions and times too far in the past from the arrays.
    /// </summary>
    /// <param name="positionList"></param>
    /// <param name="timeList"></param>
    void ClearTimes(List<Kinect.CameraSpacePoint> positionList, List<double> timeList)
    {
        for (int i = timeList.Count - 1; i >= 0; i--)
        {
            if (timeList[i] > maxCheckedTime)
            {
                timeList.RemoveAt(i);
                positionList.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Compare the past positions of a hand with each other.
    /// </summary>
    /// <param name="point"></param>
    /// <param name="left"></param>
    void ComparePosition(Kinect.CameraSpacePoint point, bool left)
    {
        if (left)
        {
            if (previousLeftHandPositions.Count > 1)
            {
                foreach (Kinect.CameraSpacePoint previousPoint in previousLeftHandPositions)
                {
                    if (point.X - previousPoint.X < -minDistance)
                    {
                        leftNewspaper.CreateNewspaper(-1);
                        animationScript.PlayAnimation("Throwing Left");
                        previousLeftHandPositions.Clear();
                        previousTimesLeft.Clear();
                        break;
                    }
                }
            }
        }
        else
        {
            if (previousRightHandPositions.Count > 1)
            {
                foreach (Kinect.CameraSpacePoint previousPoint in previousRightHandPositions)
                {
                    if (point.X - previousPoint.X > minDistance)
                    {
                        rightNewspaper.CreateNewspaper(1);
                        animationScript.PlayAnimation("Throwing Right");
                        previousRightHandPositions.Clear();
                        previousTimesRight.Clear();
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Compares the lean value of the player.
    /// </summary>
    /// <param name="lean"></param>
    void CompareLean(Kinect.PointF lean)
    {
        if (lean.X > minCheckedLean)
        {
            animationScript.anim = false;
            movementScript.Turn(1);
            animationScript.PlayAnimation("Steering Right");
        }
        else if (lean.X < -minCheckedLean)
        {
            animationScript.anim = false;
            movementScript.Turn(-1);
            animationScript.PlayAnimation("Steering Left");
        }
        else
        {
            animationScript.anim = true;
        }

        if (lean.Y > minCheckedLean)
        {
            movementScript.Accelerate();
        }
        else if (lean.Y < -minCheckedLean)
        {
            movementScript.Decelerate();
        }
    }

    /// <summary>
    /// Check if the arms are crossed by checking if the hands are on the opposite sites of each other.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="margin"></param>
    void CompareHands(Kinect.CameraSpacePoint left, Kinect.CameraSpacePoint right, float margin)
    {
        if (left.X > right.X + margin)
        {
            escapeScript.LoadMainMenu();
        }
    }
}
