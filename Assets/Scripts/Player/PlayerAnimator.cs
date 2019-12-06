using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        if (GetComponent<ControlledVelocity>().speed != 0) gameObject.GetComponent<Animator>().Play("Player Animation");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<ControlledVelocity>().speed != 0)
        {
            timer++;

            if (timer % 210 == 0)
            {
                gameObject.GetComponent<Animator>().Play("Player Animation", -1, 0.05f);
            }
        }
    }
}
