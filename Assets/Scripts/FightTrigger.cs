using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    public Animator animatedObjectAnimator;
    public Animator gnomeAnimator;

    private bool hasEnteredTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasEnteredTrigger)
            return;

        if (other.CompareTag("AnimatedObject"))
        {
            animatedObjectAnimator.SetTrigger("CharacterHitting"); // Trigger animated object's animation
        }
        else if (other.CompareTag("Gnome"))
        {
            gnomeAnimator.SetTrigger("GnomeRunningAnimation"); // Trigger gnome's animation
        }

        hasEnteredTrigger = true;
    }
}
