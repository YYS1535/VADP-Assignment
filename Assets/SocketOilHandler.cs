using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketOilHandler : MonoBehaviour
{
    [SerializeField] private OilCount oilCount; // Reference to the OilCount script

    private void OnEnable()
    {
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        if (socket != null)
        {
            socket.selectEntered.AddListener(OnObjectPlaced);
        }
        else
        {
            Debug.LogWarning("XRSocketInteractor not found on this GameObject!");
        }
    }

    private void OnDisable()
    {
        XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
        if (socket != null)
        {
            socket.selectEntered.RemoveListener(OnObjectPlaced);
        }
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        if (oilCount != null)
        {
            // Ensure the transform is converted to a GameObject
            GameObject placedObject = args.interactableObject.transform.gameObject;
            oilCount.AddOilWithDelay(placedObject);
        }
        else
        {
            Debug.LogWarning("OilCount reference is not assigned!");
        }
    }
}