using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    public GameObject dropdownMenuPrefab; // Assign your dropdown menu prefab here
    private GameObject currentDropdownMenu;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Detect collider under the mouse
            {
                // Destroy existing menu if one exists
                if (currentDropdownMenu != null)
                {
                    Destroy(currentDropdownMenu);
                }
                else
                {
                    // Get the position of the hit collider
                    Vector3 spawnPosition = hit.collider.transform.position;

                    // Create and position the dropdown menu
                    currentDropdownMenu = Instantiate(dropdownMenuPrefab, transform);
                    RectTransform menuRect = currentDropdownMenu.GetComponent<RectTransform>();

                    // Convert world position to canvas space
                    RectTransform canvasRect = GetComponent<RectTransform>();
                    Vector2 viewportPoint = Camera.main.WorldToViewportPoint(spawnPosition);
                    Vector2 canvasPoint = new Vector2(
                        (viewportPoint.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f),
                        (viewportPoint.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)
                    );

                    menuRect.anchoredPosition = canvasPoint;
                }
                
            }
        }
    }
}
