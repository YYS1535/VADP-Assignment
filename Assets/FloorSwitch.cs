using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSwitch : MonoBehaviour
{
    public FloorSwitchManager manager; // Reference to the manager script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Switch Triggered");
            manager.ActivateSwitch(gameObject); // Activate the switch in the manager
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            manager.ResetSwitchAnim(gameObject); // Reset the current switch's animation
        }
    }
}