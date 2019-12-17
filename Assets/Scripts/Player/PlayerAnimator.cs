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

    private void Update()
    {
        // Alle animaties afspelen op het juiste moment.

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Animator>().Play("Steering Left", -1, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Animator>().Play("Steering Right", -1, 0f);
        }
        else if (Input.GetKey(KeyCode.N))
        {
            if (FindObjectOfType<HUDManager>().newsPaperCheck())
            {
                gameObject.GetComponent<Animator>().Play("Throwing Left");
            }
        }
        else if (Input.GetKey(KeyCode.M))
        {
            if (FindObjectOfType<HUDManager>().newsPaperCheck())
            {
                gameObject.GetComponent<Animator>().Play("Throwing Right");
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("Player Animation");
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
                gameObject.GetComponent<Animator>().Play(animation);
                break;
            default:
                gameObject.GetComponent<Animator>().Play("Player Animation");
                break;
        }
    }
}
