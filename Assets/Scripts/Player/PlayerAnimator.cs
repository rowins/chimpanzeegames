using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    int timer;

    void Start()
    {
        timer = 0;
        if (GetComponent<ControlledVelocity>().speed != 0) gameObject.GetComponent<Animator>().Play("Player Animation");
    }

    void FixedUpdate()
    {
        if (GetComponent<ControlledVelocity>().speed != 0)
        {
            gameObject.GetComponent<Animator>().speed = GetComponent<ControlledVelocity>().speed / (GetComponent<ControlledVelocity>().maxSpeed / 2);
            timer++;

            if (timer % 210 == 0)
            {
                gameObject.GetComponent<Animator>().Play("Player Animation", -1, 0.05f);
            }
        }

        else
        {
            gameObject.GetComponent<Animator>().speed = 0;
        }
    }
}
