using System.Collections;
using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    public GnomeController gnomeController;

    private bool hasEnteredTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimatedObject") && !hasEnteredTrigger)
        {
            hasEnteredTrigger = true;
            StartCoroutine(DelayedEnableAnimatorController());
        }
    }

    private IEnumerator DelayedEnableAnimatorController()
    {
        // Wait for 3 minutes (180 seconds)
        yield return new WaitForSeconds(210f);

        // Enable the animator controller of the gnome
        gnomeController.EnableAnimator();
    }
}
