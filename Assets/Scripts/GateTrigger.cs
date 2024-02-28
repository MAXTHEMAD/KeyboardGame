using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public Animator gateAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            gateAnimator.SetTrigger("FallingGate"); // Trigger the "Open" animation
        }
    }
}
