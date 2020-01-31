﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class MenuKinect : MonoBehaviour
{
    public Menu menu;
    public GameObject Hand;
    public GameObject BodySourceManager;
    private BodySourceManager bodyManager;

    public float playButtonTop = 3f;
    public float playButtonBottom = 1.5f;
    public float exitButtonTop = 0.5f;
    public float exitButtonBottom = -1.5f;

    public float closedHandReset = 1f;
    private float closedHandTimer;

    private bool pressedButton = false;
    public float pressedReset = 1f;
    private float pressedTimer;

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
            if (pressedButton)
            {
                sprite.color = new Color(0, 0, 1);
            }
            else
            {
                sprite.color = new Color(0, 1, 0);
            }
            closedHandTimer = closedHandReset;

            if (!pressedButton) // Since we're checking the hand's position every frame and a player can't physically close their hand for just one, we need some protection against pressing a button and immediately pressing another that is right beneath it.
            {
                if (menu.PressAButton(position.y))
                {
                    pressedTimer = pressedReset;
                    pressedButton = true;
                    sprite.color = new Color(0, 0, 1);
                }
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

        pressedTimer -= Time.deltaTime;
        if (pressedTimer < 0)
        {
            pressedTimer = pressedReset;
            pressedButton = false;
        }
    }
}