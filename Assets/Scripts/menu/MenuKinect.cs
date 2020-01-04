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

    public ButtonRange playButton;
    public ButtonRange exitButton;

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
            Kinect.Joint hand = joints[Kinect.JointType.HandRight];
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

        Vector3 position = new Vector3(handPosition.X * 3, handPosition.Y * 3, handPosition.Z) * 10;
        Hand.transform.SetPositionAndRotation(position, Hand.transform.rotation);

        SpriteRenderer sprite = Hand.GetComponent<SpriteRenderer>();

        if (handClosed)
        {
            //Indicate the hand was closed
            sprite.color = new Color(0, 1, 0);
            closedHandTimer = closedHandReset;

            if (playButton.InYRange(position.y))
            {
                menu.PlayGame();
            }
            else if (exitButton.InYRange(position.y))
            {
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
}
