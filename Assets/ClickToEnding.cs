using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToEnding : MonoBehaviour
{
    public Animator Pod; // Assign the door's Animator component in the Inspector

    public void OpenDoor1()
    {
        Debug.Log("sj");
        if (Pod != null)
        {
            Pod.SetBool("isOpen", true); // Assumes 'isOpen' is a parameter in the Animator
        }
    }
}
