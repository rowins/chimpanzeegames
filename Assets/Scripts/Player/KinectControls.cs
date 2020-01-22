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
    // Scripts to call functions in
    public ThrowNewspaper leftNewspaper;
    public ThrowNewspaper rightNewspaper;
    public ControlledVelocity movementScript;
    public PlayerAnimator animationScript;

    #region Values for Function Example, NOT to be in Final Product
    public Vector3 movement = new Vector3(3, 0, 0);
    public Vector3 moveSideways = new Vector3(0.2f, 0, 0);
    public Vector3 moveUpDown = new Vector3(0, 0.2f, 0);
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            if (leftHand.Position == rightHand.Position)
            {
                continue;
            }
            leftHandPosition = leftHand.Position;
            rightHandPosition = rightHand.Position;
            lean = body.Lean;
            break;
        }
        #endregion

        #region Hand Movement Input
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

        #region Body Lean Input
        CompareLean(lean);
        #endregion
    }

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
                        //transform.Translate(-movement); // Implementeer hier krant naar links gooien, deze regel verplaats het object nu als test
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
                        //transform.Translate(movement); // Implementeer hier krant naar recht gooien, deze regel verplaats het object nu als test
                        previousRightHandPositions.Clear();
                        previousTimesRight.Clear();
                        break;
                    }
                }
            }
        }
    }

    void CompareLean(Kinect.PointF lean)
    {
        if (lean.X > minCheckedLean)
        {
            movementScript.Turn(1);
            animationScript.PlayAnimation("Steering Right");
            //transform.Translate(moveSideways); // Implementeer hier naar rechts sturen, deze regel verplaats het object nu als test
        }
        else if (lean.X < -minCheckedLean)
        {
            movementScript.Turn(-1);
            animationScript.PlayAnimation("Steering Left");
            //transform.Translate(-moveSideways); // Implementeer hier naar links sturen, deze regel verplaats het object nu als test
        }

        if (lean.Y > minCheckedLean)
        {
            movementScript.Accelerate();
            //transform.Translate(moveUpDown); // Implementeer hier versnellen, deze regel verplaats het object nu als test
        }
        else if (lean.Y < -minCheckedLean)
        {
            movementScript.Decelerate();
            //transform.Translate(-moveUpDown); // Implementeer hier afremmen, deze regel verplaats het object nu als test
        }
    }
}
