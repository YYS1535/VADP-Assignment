using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToEnding : MonoBehaviour
{
    public Animator Pod; // Assign the door's Animator component in the Inspector
    public CanvasGroup fadeCanvasGroup; // Assign a UI CanvasGroup for fading effect
    public float fadeDuration = 3.0f; // Time for fade-out effect
    public string nextSceneName = "FinalScene"; // The name of the scene to load after the animation

    public void EndingSceneAnimation()
    {
        Debug.Log("Button Pressed!");
        if (Pod != null)
        {
            StartCoroutine(DelayedAnimationAndTransition());
        }
    }

    private IEnumerator DelayedAnimationAndTransition()
    {
        // Delay the animation trigger
        yield return new WaitForSeconds(3f);

        // Trigger the EndGame animation
        Pod.SetBool("EndGame", true);

        // Start fading the screen to black
        yield return StartCoroutine(FadeToBlack());

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator FadeToBlack()
    {
        if (fadeCanvasGroup == null)
        {
            Debug.LogWarning("Fade CanvasGroup is not assigned!");
            yield break;
        }

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(timer / fadeDuration); // Increase alpha gradually
            yield return null;
        }
    }
}
