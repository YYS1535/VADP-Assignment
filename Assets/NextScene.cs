using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void GoToNextScene()
    {
        SceneManager.LoadScene("Environment");
    }
    public void GoToNextScene1()
    {
        SceneManager.LoadScene("MainMenu2");
    }
}
