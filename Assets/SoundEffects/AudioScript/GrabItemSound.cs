using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabItemSound : MonoBehaviour
{
    public AudioSource grabSound;  // ????

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (grabSound != null)
        {
            grabSound.Play();
        }
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);  // ????
    }
}
