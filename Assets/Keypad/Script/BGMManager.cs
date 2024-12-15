using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    public void Awake()
    {
        // Ensure only one instance of the BGMManager exists
        if (instance != null)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Prevent destruction on scene load
    }
}

