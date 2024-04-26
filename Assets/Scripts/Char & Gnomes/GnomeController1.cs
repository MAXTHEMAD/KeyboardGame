using UnityEngine;

public class GnomeController : MonoBehaviour
{
    private Animator gnomeAnimator;

    private void Start()
    {
        gnomeAnimator = GetComponent<Animator>();
        // Disable the Animator Controller by default
        gnomeAnimator.enabled = false;
    }

    // Add a public method to enable the Animator Controller
    public void EnableAnimator()
    {
        gnomeAnimator.enabled = true;
    }

    // Add a public method to disable the Animator Controller
    public void DisableAnimator()
    {
        gnomeAnimator.enabled = false;
    }
}
