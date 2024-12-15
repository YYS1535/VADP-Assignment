using UnityEngine;
using System.Collections;

public class Playsound1 : MonoBehaviour
{
    public void Clicky()
    {
        GetComponent<AudioSource>().Play();
    }
}
