using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerEndAnimationHandler : MonoBehaviour
{
    public Animator animator; // Assign the Animator component in the inspector.
    public string animationTriggerName = "EndGame"; // Set the name of the trigger parameter in the Animator.
    public string nextSceneName; // The name of the scene to load after the animation ends.

    private bool animationTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Debug: 检查碰撞对象的名称和标签
        Debug.Log($"OnTriggerEnter called with object: {other.name}, tag: {other.tag}");

        // Check if the player enters the collider.
        if (other.CompareTag("Player") && !animationTriggered)
        {
            animationTriggered = true; // Ensure the animation only triggers once.
            Debug.Log("Player entered the collider. Triggering animation.");
            TriggerAnimation();
        }
        else
        {
            Debug.Log("Collider triggered by a non-player object or animation already triggered.");
        }
    }

    private void TriggerAnimation()
    {
        if (animator != null && !string.IsNullOrEmpty(animationTriggerName))
        {
            Debug.Log("Triggering animation: " + animationTriggerName);
            animator.SetTrigger(animationTriggerName); // Play the animation.
            StartCoroutine(WaitForAnimationToEnd());
        }
        else
        {
            Debug.LogWarning("Animator or animation trigger name is not set!");
        }
    }

    private IEnumerator WaitForAnimationToEnd()
    {
        Debug.Log("Waiting for animation to complete...");

        // Wait for the animation to complete before transitioning to the next scene.
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Wait until the current animation state is fully started.
        while (stateInfo.shortNameHash != animator.GetCurrentAnimatorStateInfo(0).shortNameHash)
        {
            Debug.Log("Waiting for animation to start...");
            yield return null;
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }

        Debug.Log("Animation started. Waiting for length: " + stateInfo.length);
        yield return new WaitForSeconds(stateInfo.length);

        // Load the next scene.
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("Loading next scene: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not set!");
        }
    }
}
