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

    // Audio components
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip correctPasswordSound; // Sound to play when password is correct

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
            PlayCorrectPasswordSound(); // Play the sound effect
            OpenDoor(); // Trigger door animation
        }
        else
        {
            Debug.Log("Password Incorrect.");
            playerInput = ""; // Reset the input if incorrect
        }
    }

    // Plays the correct password sound effect
    private void PlayCorrectPasswordSound()
    {
        if (audioSource != null && correctPasswordSound != null)
        {
            audioSource.PlayOneShot(correctPasswordSound); // Play the sound effect
        }
        else
        {
            Debug.LogWarning("AudioSource or CorrectPasswordSound is not set!");
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
        if (Pin != null)
        {
            Pin.text = playerInput;
        }
    }
}

