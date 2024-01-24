using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class ConvoManager : MonoBehaviour
{
    public NativeSpline spline;
    public float speed = 5f;
    public float pauseDuration = 2f;

    private float progress = 0f;
    private bool isPaused = false;

    void Update()
    {
        if (!isPaused)
        {
            MoveAlongSpline();
        }
    }

    void MoveAlongSpline()
    {
        progress += Time.deltaTime * speed / spline.GetLength();
        if (progress > 1f)
        {
            progress = 1f;
        }

      
    }

    IEnumerator PauseForConversation()
    {
        isPaused = true;

        // Trigger conversation here
        // For example: ConversationManager.StartConversation();

        yield return new WaitForSeconds(pauseDuration);

        // Finish conversation here
        // For example: ConversationManager.EndConversation();

        isPaused = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConversationTrigger"))
        {
            StartCoroutine(PauseForConversation());
        }
    }
}
