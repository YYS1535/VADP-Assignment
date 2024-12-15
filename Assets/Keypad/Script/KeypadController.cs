using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeypadController : MonoBehaviour
{
    public string correctPassword = "1234"; // Set the password here
    public string playerInput = ""; // To store player's input
    [SerializeField] private TextMeshProUGUI Pin; // Reference to the TMP text field


    public Animator Door1; // Assign the door's Animator component in the Inspector

    // This function is called when a keypad button is pressed
    public void AddDigit(string digit)
    {
        playerInput += digit; // Append the digit to the input string
        UpdatePinDisplay();
        Debug.Log("Current Input: " + playerInput);
    }

    // This function is called to check the password
    public void CheckPassword()
    {
        if (playerInput == correctPassword)
        {
            Debug.Log("Password Correct!");
            OpenDoor(); // Trigger door animation
        }
        else
        {
            Debug.Log("Password Incorrect.");
            playerInput = ""; // Reset the input if incorrect
        }
    }

    // Opens the door by triggering the animation
    private void OpenDoor()
    {
        if (Door1 != null)
        {
            Door1.SetBool("isOpen", true); // Assumes 'isOpen' is a parameter in the Animator
        }
    }

    // Clears the input (optional, for a reset button)
    public void ClearInput()
    {
        playerInput = "";
        UpdatePinDisplay();
    }
    // Updates the PIN text display
    public void UpdatePinDisplay()
    {
        
            Pin.text = playerInput;
            Debug.Log("eon");
        
    }

    public string correctSequence = "2361"; // The correct memory game sequence
    public string playerInput1 = ""; // To store player's input
    [SerializeField] private TextMeshProUGUI Number9; // Reference to success message TMP text
    [SerializeField] private float resetDelay = 1.0f; // Delay before resetting after a wrong input

    // This function is called when a keypad button is pressed
    public void AddNum(string digit)
    {
        playerInput1 += digit; // Append the digit to the input string
        Debug.Log("Current Input: " + playerInput1);

        // Check the sequence if the player has entered enough digits
        if (playerInput1.Length == correctSequence.Length)
        {
            CheckSequence();
        }
    }

    // This function checks if the player's input matches the correct sequence
    public void CheckSequence()
    {
        if (playerInput1 == correctSequence)
        {
            Debug.Log("Sequence Correct!");
            ShowSuccessMessage(); // Show success message
        }
        else
        {
            Debug.Log("Sequence Incorrect. Resetting...");
            StartCoroutine(ResetInput()); // Reset after a delay
        }
    }

    public IEnumerator ResetInput()
    {
        yield return new WaitForSeconds(resetDelay); // Wait for the reset delay
        playerInput1 = ""; // Clear the input
        Debug.Log("Input Reset. Try Again.");
    }
}
