using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSwitch : MonoBehaviour
{
    public FloorSwitchManager FloorSwitchManager;
    public float loweredY = -0.5f; // Target Y position when pressed
    public float raisedY = 0f;    // Default Y position
    public float moveDuration = 0.25f; // Time to move (in seconds)

    public Vector3 startPosition { get; private set; } // Exposed for the manager
    public Vector3 targetPosition { get; private set; } // Tracks the last movement target for the switch

    private void Start()
    {
        startPosition = transform.position; // Record initial position
        targetPosition = startPosition;    // Initial target is the starting position
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // Ensure only player activates the switch
        {
            MoveSwitchTo(loweredY); // Lower the switch
            FloorSwitchManager.OnSwitchPressed(this); // Notify the manager
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            MoveSwitchTo(raisedY); // Raise the switch
        }
    }

    public void MoveSwitchTo(float targetY)
    {
        // Set the calculated target position
        targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        // Use DOTween to move the object
        transform.DOMove(targetPosition, moveDuration).SetEase(Ease.InOutSine);
        //Debug.Log($"Moving to Target Position: {targetPosition}");
    }
}