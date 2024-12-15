using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class L2KeyoadController1 : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the AudioSource
    public string correctPassword = "2120"; // Set the password here
    public string playerInput = ""; // To store player's input
    [SerializeField] private TextMeshProUGUI Pin; // Reference to the TMP text field

    public Material[] material; // Array for materials
    private Renderer rend; // Renderer of the current GameObject
    [SerializeField] private GameObject targetObject; // Reference to the target GameObject

    public AudioClip correctSound; // Sound for correct switch
    public AudioClip wrongSound;   // Sound for wrong switch

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on this GameObject. Please add one.");
        }

        // Set the initial material for the target object
        if (targetObject != null)
        {
            Renderer targetRenderer = targetObject.GetComponent<Renderer>();
            if (targetRenderer != null)
            {
                targetRenderer.sharedMaterial = material[0];
            }
            else
            {
                Debug.LogError("Target object does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogError("Target object is not assigned in the Inspector.");
        }
    }

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
            if (audioSource != null && correctSound != null)
            {
                audioSource.PlayOneShot(correctSound);
            }

            // Change the material of the target object
            if (targetObject != null)
            {
                Renderer targetRenderer = targetObject.GetComponent<Renderer>();
                if (targetRenderer != null)
                {
                    targetRenderer.sharedMaterial = material[1];
                }
                else
                {
                    Debug.LogError("Target object does not have a Renderer component.");
                }
            }
            else
            {
                Debug.LogError("Target object is not assigned in the Inspector.");
            }
        }
        else
        {
            Debug.Log("Password Incorrect.");
            if (audioSource != null && wrongSound != null)
            {
                audioSource.PlayOneShot(wrongSound);
            }
            playerInput = ""; // Reset the input if incorrect
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
        Debug.Log("update pin display");
    }
}
