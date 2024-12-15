using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FloorSwitchManager : MonoBehaviour
{
    public List<FloorSwitch> floorSwitches; // List of switches in the correct order
    private int currentStep = 0;            // Current switch to step on
    public bool puzzleSolved = false;
    public Animator Door2; // Reference to the door's Animator

    public Color initialColor = Color.red; // Color when the switch is reset or unpressed
    public Color correctColor = Color.green; // Color when the switch is correctly pressed

    public AudioClip correctSound; // Sound for correct switch
    public AudioClip wrongSound;   // Sound for wrong switch
    public AudioClip openDoorSound;

    private void Start()
    {
        // Set all switches to the initial color on start
        foreach (FloorSwitch floorSwitch in floorSwitches)
        {
            SetSwitchColor(floorSwitch, initialColor);
        }
    }

    public void OnSwitchPressed(FloorSwitch switchPressed)
    {
        if (puzzleSolved) return;

        AudioSource audioSource = switchPressed.GetComponent<AudioSource>();

        if (floorSwitches[currentStep] == switchPressed)
        {
            Debug.Log("Correct Switch!");
            currentStep++;

            // Set the switch to the correct color
            SetSwitchColor(switchPressed, correctColor);

            // Play the correct sound
            if (audioSource != null && correctSound != null)
            {
                audioSource.PlayOneShot(correctSound);
            }

            // If all switches are stepped in the correct order
            if (currentStep >= floorSwitches.Count)
            {
                Door2.SetBool("isOpen", true);
                if (audioSource != null && openDoorSound != null)
                {
                    audioSource.PlayOneShot(openDoorSound);
                }
                puzzleSolved = true;
                Debug.Log("Puzzle Solved!");
            }
        }
        else
        {
            Debug.Log("Wrong Switch! Resetting...");

            // Play the wrong sound
            if (audioSource != null && wrongSound != null)
            {
                audioSource.PlayOneShot(wrongSound);
            }

            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        if (puzzleSolved) return;

        currentStep = 0;

        // Reset all switches to the initial color and position
        foreach (FloorSwitch floorSwitch in floorSwitches)
        {
            SetSwitchColor(floorSwitch, initialColor);
            floorSwitch.MoveSwitchTo(floorSwitch.raisedY);
        }
    }

    private void SetSwitchColor(FloorSwitch floorSwitch, Color color)
    {
        // Get the MeshRenderer of the switch and set its color
        MeshRenderer renderer = floorSwitch.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}