using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] GameObject dropdownMenuPrefab; // Assign your dropdown menu prefab here
    [SerializeField] GameObject optionPrefab;

    [SerializeField] GameObject[] towers;

    [SerializeField] LayerMask layerMask;

    private GameObject currentDropdownMenu;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIElement()) // Left-click
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            Debug.Log("Casting ray");

            if (hit.collider != null) // Detect collider under the mouse
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
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
                    CreateOptions(hit.collider.tag, currentDropdownMenu, spawnPosition);
                }
                
            }
        }
    }

    void CreateOptions(string tag, GameObject menu, Vector3 worldPosition)
    {
        RectTransform rectTransform = menu.GetComponent<RectTransform>();
        Vector3 menuPosition = rectTransform.position;
        switch (tag) {
            case "Free": 
                GameObject Turret = Instantiate(optionPrefab, menu.transform);
                Turret.GetComponent<RectTransform>().position = menuPosition + Vector3.up;
                Turret.GetComponent<CreateTower>().Tower = towers[0];
                Turret.GetComponent<CreateTower>().Position = worldPosition;

                GameObject Pylon = Instantiate(optionPrefab, menu.transform);
                Pylon.GetComponent<RectTransform>().position = menuPosition + Vector3.left;
                Pylon.GetComponent<CreateTower>().Tower = towers[1];
                Pylon.GetComponent<CreateTower>().Position = worldPosition;

                GameObject Light = Instantiate(optionPrefab, menu.transform);
                Light.GetComponent<RectTransform>().position = menuPosition + Vector3.right;
                Light.GetComponent<CreateTower>().Tower = towers[2];
                Light.GetComponent<CreateTower>().Position = worldPosition;
                break;
        }
    }

    private bool IsPointerOverUIElement()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }
}
