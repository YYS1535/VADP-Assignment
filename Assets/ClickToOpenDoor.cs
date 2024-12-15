using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToOpenDoor : MonoBehaviour
{
    public Animator OpenDoor; // Assign the door's Animator component in the Inspector

    public void OpenDoor1()
    {
        Debug.Log("sj");
        if (OpenDoor != null)
        {
            OpenDoor.SetBool("isOpen", true); // Assumes 'isOpen' is a parameter in the Animator
        }
    }
}
