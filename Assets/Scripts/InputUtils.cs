using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InputUtils : MonoBehaviour
{
    // Call this function to check if the mouse is over a UI element
    public static bool IsPointerOverUIElement()
    {
        // Get the current EventSystem
        EventSystem eventSystem = EventSystem.current;

        // Set up the new Pointer Event
        PointerEventData pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition // use the current mouse position
        };

        // Create a list to receive all results
        List<RaycastResult> results = new List<RaycastResult>();

        // Raycast using the Graphics Raycaster and mouse click position
        eventSystem.RaycastAll(pointerEventData, results);

        // For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            Debug.Log("Hit " + result.gameObject.name);
        }

        // Return true if any results are found
        return results.Count > 0;
    }
}
