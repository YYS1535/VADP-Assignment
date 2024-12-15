using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FloorSwitchManager : MonoBehaviour
{
    public GameObject[] switches; // Array to hold floor switch objects
    public Animator Door2; // Reference to the door's Animator
    public int currentSwitchIndex = 0; // Tracks the correct order of switches
    public Color transparentGreen = new Color(0f, 1f, 0f, 0.5f); // Transparent green
    public Color transparentRed = new Color(1f, 0f, 0f, 0.5f); // Transparent red
    private Animator currentAnim; // To keep track of the last activated switch's animator

    void Start()
    {
        // Initialize switches (set all to red and reset animators)
        for (int i = 0; i < switches.Length; i++)
        {
            switches[i].GetComponentInChildren<Renderer>().material.color = transparentRed; // Set to red
            // Ensure each switch gets its own Animator reset (if necessary)
            Animator switchAnimator = switches[i].GetComponentInParent<Animator>();
            if (switchAnimator != null)
            {
                switchAnimator.SetBool("isStep", false); // Reset the "step" state to false at the beginning
            }
        }
    }

    public void ActivateSwitch(GameObject switchTriggered)
    {
        Debug.Log("Switch Activated");

        if (currentSwitchIndex < switches.Length)
        {
            // Check if the triggered switch matches the next in the sequence
            if (switchTriggered == switches[currentSwitchIndex])
            {
                Animator anim = switchTriggered.GetComponentInParent<Animator>();
                anim.SetBool("isStep", true); // Trigger the "step-down" animation for the current switch

                // Correct switch triggered
                switchTriggered.GetComponent<Renderer>().material.color = transparentGreen; // Set to green
                currentSwitchIndex++;

                // Update the current switch's animator
                currentAnim = anim;

                // Check if all switches have been triggered
                if (currentSwitchIndex >= switches.Length)
                {
                    OpenDoor();
                }
            }
            else
            {
                // Wrong switch triggered, reset the sequence
                ResetSwitches();
            }
        }
    }

    private void OpenDoor()
    {
        Door2.SetBool("isOpen", true);
        Debug.Log("Door Opened!");
    }

    private void ResetSwitches()
    {
        currentSwitchIndex = 0;
        for (int i = 0; i < switches.Length; i++)
        {
            switches[i].GetComponentInChildren<Renderer>().material.color = transparentRed; // Reset to red
            Animator anim = switches[i].GetComponentInParent<Animator>();
            anim.SetBool("isStep", false); // Reset the "step-up" animation for all switches
        }
        Debug.Log("Sequence Reset!");
    }

    public void ResetSwitchAnim(GameObject switchTriggered)
    {
        Animator anim = switchTriggered.GetComponentInParent<Animator>();
        anim.SetBool("isStep", false); // Reset the "step-up" animation for the current switch
    }
}