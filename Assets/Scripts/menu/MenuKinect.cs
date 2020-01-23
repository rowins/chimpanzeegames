using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class MenuKinect : MonoBehaviour
{
    public menu menu;
    public GameObject Hand;
    public GameObject BodySourceManager;
    private BodySourceManager bodyManager;

    public float playButtonTop = 3f;
    public float playButtonBottom = 1.5f;
    public float exitButtonTop = 0.5f;
    public float exitButtonBottom = -1.5f;

    public float closedHandReset = 1f;
    private float closedHandTimer;

    // Start is called before the first frame update
    void Start()
    {
        closedHandTimer = closedHandReset;
    }

    // Update is called once per frame
    void Update()
    {
        Kinect.CameraSpacePoint handPosition = new Kinect.CameraSpacePoint();
        bool handClosed = false;

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
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }
            Dictionary<Kinect.JointType, Kinect.Joint> joints = body.Joints;
            if (!joints.ContainsKey(Kinect.JointType.HandRight))
            {
                continue;
            }
            if (!joints.ContainsKey(Kinect.JointType.HandLeft))
            {
                continue;
            }
            Kinect.Joint hand = joints[Kinect.JointType.HandRight];
            Kinect.Joint testHand = joints[Kinect.JointType.HandLeft];
            if (hand.Position == testHand.Position) // Since two hands cannot be in the same position, this serves as a good check to make sure the non-null body we have does not have all default values.
            {
                continue;
            }
            handPosition = hand.Position;
            if (body.HandRightState == Kinect.HandState.Closed)
            {
                handClosed = true;
            }
            break;
        }
        if (Hand == null)
        {
            return;
        }

        Vector3 position = new Vector3(handPosition.X, handPosition.Y, 0) * 10;
        Hand.transform.SetPositionAndRotation(position, Hand.transform.rotation);

        SpriteRenderer sprite = Hand.GetComponent<SpriteRenderer>();

        if (handClosed)
        {
            //Indicate the hand was closed
            sprite.color = new Color(0, 1, 0);
            closedHandTimer = closedHandReset;

            if (InYRange(position.y, playButtonTop, playButtonBottom))
            {
                sprite.color = new Color(0, 0, 1);
                menu.PlayGame();
            }
            else if (InYRange(position.y, exitButtonTop, exitButtonBottom))
            {
                sprite.color = new Color(1, 1, 0);
                menu.ExitGame();
            }
            
        }
        else
        {
            closedHandTimer -= Time.deltaTime;
            if (closedHandTimer < 0)
            {
                closedHandTimer = closedHandReset;
                sprite.color = new Color(1, 0, 0);
            }
        }
        
    }

    public bool InYRange(float Y, float top, float bottom) // Unfortunately it seems the values for top and bottom have to be hardcoded and discovered by hand, which is problematic if one wants to add more buttons
    {
        if ((Y < top) && (Y > bottom))
        {
            return true;
        }
        return false;
    }
}
