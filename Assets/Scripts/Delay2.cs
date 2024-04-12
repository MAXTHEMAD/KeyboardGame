using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay2 : MonoBehaviour
{
    public float delaySeconds = 2.0f; // Delay in seconds
    public AnimationClip idleAnimationClip; // Animation clip for the idle animation
    // public GameObject idlePrefab; // Prefab containing the idle animation

    private Animator animator;
    private bool animationStarted = false;
    private float startTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        startTime = Time.time + delaySeconds; // Calculate the exact time when the animation should start

        if (idleAnimationClip != null)
        {
            // Play the idle animation clip on the animator component
            animator.Play(idleAnimationClip.name);
        }
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
