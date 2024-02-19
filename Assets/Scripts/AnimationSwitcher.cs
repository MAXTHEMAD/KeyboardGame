using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // This method is called when a collision occurs
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object that has a Box Collider
        if (collision.collider.CompareTag("Switch"))
        {
            // Trigger the animation switch
            animator.SetTrigger("SwitchAnimationTrigger");
        }
    }
}
