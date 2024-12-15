using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel2 : MonoBehaviour
{
    // Detect collision with the MainCamera
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // Check if the object colliding is tagged as "MainCamera"
        {
            Debug.Log("Player entered trigger, loading Level 2...");
            SceneManager.LoadScene("level_2");
        }
    }
}
