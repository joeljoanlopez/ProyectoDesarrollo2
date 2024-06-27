using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GridClass<int> grid;
    public GameObject singleSlotPrefab;  // Prefab for single slot objects
    public GameObject doubleSlotPrefab;  // Prefab for double slot objects

    private GridObject selectedGridObject;
    private Vector3 initialPosition;

    private void Start()
    {
        Vector3 originPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        originPosition.z = 0;  // Ensure the z-coordinate is 0
        grid = new GridClass<int>(20, 10, 1f, originPosition);
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        Debug.Log($"Mouse World Position: {mouseWorldPosition}");

        if (Input.GetMouseButtonDown(0))
        {
            GridObject gridObject = grid.GetGameObject(mouseWorldPosition);
            if (gridObject != null)
            {
                selectedGridObject = gridObject;
                initialPosition = mouseWorldPosition;
            }
            else
            {
                // Add a single slot object
                grid.SetValue(mouseWorldPosition, 56);  // Set the value to an int
                grid.AddGameObject(mouseWorldPosition, singleSlotPrefab);  // Add the single slot GameObject

                // Add a double slot object (example usage, you can customize the condition)
                Vector3 doubleSlotPosition = mouseWorldPosition + new Vector3(2, 0);  // Example offset for demonstration
                grid.AddGameObject(doubleSlotPosition, doubleSlotPrefab, 2, 1);  // Add the double slot GameObject
            }
        }

        if (selectedGridObject != null)
        {
            selectedGridObject.GameObject.transform.position = mouseWorldPosition;

            if (Input.GetMouseButtonUp(0))
            {
                grid.RemoveGameObject(initialPosition);
                Vector3? nearestEmptyCell = grid.FindNearestEmptyCell(mouseWorldPosition, selectedGridObject.SizeX, selectedGridObject.SizeY);
                if (nearestEmptyCell.HasValue)
                {
                    grid.AddGameObject(nearestEmptyCell.Value, selectedGridObject.GameObject, selectedGridObject.SizeX, selectedGridObject.SizeY);
                }
                else
                {
                    grid.AddGameObject(initialPosition, selectedGridObject.GameObject, selectedGridObject.SizeX, selectedGridObject.SizeY);
                }
                selectedGridObject = null;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                selectedGridObject.Rotate();
            }
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}

