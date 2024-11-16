using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    public GameObject dropdownMenuPrefab; // Assign your dropdown menu prefab here
    private GameObject currentDropdownMenu;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            if (currentDropdownMenu != null)
            {
                Destroy(currentDropdownMenu); // Remove the previous menu if one exists
            }

            Vector2 mousePosition = Input.mousePosition;

            // Create and position the dropdown menu at the mouse position
            currentDropdownMenu = Instantiate(dropdownMenuPrefab, transform);
            RectTransform menuRect = currentDropdownMenu.GetComponent<RectTransform>();

            // Convert screen point to local point in canvas space
            RectTransform canvasRect = GetComponent<RectTransform>();
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, mousePosition, null, out localPoint);
            menuRect.anchoredPosition = localPoint;
        }
    }
}
