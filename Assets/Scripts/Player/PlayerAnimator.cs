using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    int timer;

    public bool anim;

    void Start()
    {
        anim = true;
        // De timer zorgt ervoor dat de animatie op het goede moment wordt gereset
        timer = 0;
        if (GetComponent<ControlledVelocity>().speed != 0) gameObject.GetComponent<Animator>().Play("Player Animation");
    }

    private void Update()
    {
        // Alle animaties afspelen op het juiste moment.

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayAnimation("Steering Left");
            //gameObject.GetComponent<Animator>().Play("Steering Left", -1, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayAnimation("Steering Right");
            //gameObject.GetComponent<Animator>().Play("Steering Right", -1, 0f);
        }
        else if (Input.GetKey(KeyCode.N))
        {
            PlayAnimation("Throwing Left");
            /*if (FindObjectOfType<HUDManager>().newsPaperCheck())
            {
                gameObject.GetComponent<Animator>().Play("Throwing Left");
            }*/
        }
        else if (Input.GetKey(KeyCode.M))
        {
            PlayAnimation("Throwing Right");
            /*if (FindObjectOfType<HUDManager>().newsPaperCheck())
            {
                gameObject.GetComponent<Animator>().Play("Throwing Right");
            }*/
        }
        else
        {
            if (anim == true)
            {
                PlayAnimation("Player Animation");
            }
            //PlayAnimation("Player Animation");
            //gameObject.GetComponent<Animator>().Play("Player Animation");
        }
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
            gameObject.GetComponent<Animator>().speed = 0; // De animatie laten stoppen
        }
    }

    public void PlayAnimation(string animation)
    {
        switch (animation)
        {
            case "Steering Left":
            case "Steering Right":
                    gameObject.GetComponent<Animator>().Play(animation, -1, 0f);
                break;
            case "Throwing Right":
            case "Throwing Left":
                if (FindObjectOfType<HUDManager>().newsPaperCheck())
                {
                    gameObject.GetComponent<Animator>().Play(animation);
                }
                break;
            default:
                gameObject.GetComponent<Animator>().Play("Player Animation");
                break;
        }
    }
}
