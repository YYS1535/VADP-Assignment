using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MemoryButton : MonoBehaviour
{
    public string correctSequence = "2361"; // The correct memory game sequence
    private string playerInput1 = ""; // To store player's input
    public GameObject Number3Panel; // Array for materials
    [SerializeField] private GameObject targetObject; // Reference to the target GameObject
    [SerializeField] private float resetDelay = 1.0f; // Delay before resetting after a wrong input

    public void Start()
    {
        // Hide the success message at the start
        if (Number3Panel != null)
        {
            Number3Panel.SetActive(false);
        }
    }

    // This function is called when a keypad button is pressed
    public void AddNum(string digit)
    {
        playerInput1 += digit; // Append the digit to the input string
        Debug.Log("Current Input: " + playerInput1);

        // Start checking only when the player has entered exactly 4 digits
        if (playerInput1.Length == 4)
        {
            CheckSequence();
        }
    }

    public void CheckSequence()
    {
        // Debug the input and the correct sequence
        Debug.Log($"Checking Sequence... Player Input: [{playerInput1}], Correct Sequence: [{correctSequence}]");

        // Trim and compare sequences
        if (playerInput1 == correctSequence)
        {
            Debug.Log("Sequence Correct!");
            ActivePanel(); // Show success message
        }
        else
        {
            Debug.Log("Sequence Incorrect. Resetting...");
            StartCoroutine(ResetInput()); // Reset after a delay
        }
    }


    // Displays the success message
    public void ActivePanel()
    {
        Debug.Log("eon");
        if (Number3Panel != null)
        {
            Number3Panel.SetActive(true); // Activate the success message text
        }
    }

    // Resets the player's input to allow them to try again
    public IEnumerator ResetInput()
    {
        yield return new WaitForSeconds(resetDelay); // Wait for the reset delay
        playerInput1 = ""; // Clear the input
        Debug.Log("Input Reset. Try Again.");
    }

}