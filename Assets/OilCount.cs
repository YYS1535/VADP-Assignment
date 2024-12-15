using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For displaying the count in the UI
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class OilCount : MonoBehaviour
{
    [SerializeField] private int requiredOilCount = 4; // Total oil barrels needed
    private int currentOilCount = 0; // Tracks how many barrels have been added

    [SerializeField] private TextMeshProUGUI oilCountText; // UI element to display progress
    [SerializeField] private GameObject oilAnimPrefab;

    private GameObject barrelToProcess;
    [SerializeField] private float addOilDelay = 2f; // Delay in seconds

    [SerializeField] private GameObject escapeCanvas; // Reference to the canvas containing the button

    void Start()
    {
        oilAnimPrefab.SetActive(false);
        if (escapeCanvas != null)
        {
            escapeCanvas.SetActive(false); // Ensure the canvas starts invisible
        }
        else
        {
            Debug.LogWarning("EscapeCanvas is not assigned!");
        }
        UpdateOilCountText(); // Initialize the UI display
    }

    public void AddOilWithDelay(GameObject oilBarrel)
    {
        if (currentOilCount < requiredOilCount)
        {
            barrelToProcess = oilBarrel; // Store the reference
            Invoke(nameof(DelayedAddOil), addOilDelay); // Schedule the delayed method
        }
        else
        {
            Debug.Log("Fueling already complete!");
        }
    }

    private void DelayedAddOil()
    {
        if (barrelToProcess != null)
        {
            barrelToProcess.SetActive(false); // Deactivate the barrel
            currentOilCount++;
            UpdateOilCountText();
            ActivateAnimation();

            if (currentOilCount == requiredOilCount)
            {
                Debug.Log("Fueling complete!");
                OnFuelingComplete();
            }
        }
        else
        {
            Debug.LogWarning("No barrel to process!");
        }
    }

    private void UpdateOilCountText()
    {
        if (oilCountText != null)
        {
            oilCountText.text = $"{currentOilCount}/{requiredOilCount}";
        }
        else
        {
            Debug.LogWarning("Oil count text UI element is not assigned!");
        }
    }

    private void ActivateAnimation()
    {
        if (oilAnimPrefab != null)
        {
            oilAnimPrefab.SetActive(true);
            Invoke(nameof(DeactivateAnimation), 2f); // Deactivate after 2 seconds
        }
        else
        {
            Debug.LogWarning("Animation prefab is not assigned!");
        }
    }

    private void DeactivateAnimation()
    {
        if (oilAnimPrefab != null)
        {
            oilAnimPrefab.SetActive(false);
        }
    }

    private void OnFuelingComplete()
    {
        // Add logic for what happens when fueling is complete
        Debug.Log("The machine is now ready to use!");

        // Make the EscapeCanvas button visible
        if (escapeCanvas != null)
        {
            escapeCanvas.SetActive(true);
            Debug.Log("EscapeCanvas is now visible.");
        }
        else
        {
            Debug.LogWarning("EscapeCanvas is not assigned!");
        }
    }
}

