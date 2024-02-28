using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Delay : MonoBehaviour
{
    public float delaySeconds = 2.0f; // Delay in seconds

    private Animator animator;
    private bool animationStarted = false;
    private float startTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        startTime = Time.time + delaySeconds; // Calculate the exact time when the animation should start
    }

    void Update()
    {
        if (!animationStarted && Time.time >= startTime)
        {
            animator.enabled = true; // Enable the animator component to start the animation
            animationStarted = true; // Set the flag to true to prevent the animation from starting again
        }
    }
}
