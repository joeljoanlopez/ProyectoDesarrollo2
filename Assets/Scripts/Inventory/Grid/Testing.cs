using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GridClass<int> grid;
    public GameObject gameObjectPrefab;

    private GameObject selectedGameObject;
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
            selectedGameObject = grid.GetGameObject(mouseWorldPosition);
            if (selectedGameObject != null)
            {
                initialPosition = mouseWorldPosition;
            }
            else
            {
                grid.SetValue(mouseWorldPosition, 56);  // Set the value to an int
                grid.AddGameObject(mouseWorldPosition, gameObjectPrefab);  // Add the GameObject
            }
        }

        if (selectedGameObject != null)
        {
            selectedGameObject.transform.position = mouseWorldPosition;

            if (Input.GetMouseButtonUp(0))
            {
                grid.RemoveGameObject(initialPosition);
                Vector3? nearestEmptyCell = grid.FindNearestEmptyCell(mouseWorldPosition);
                if (nearestEmptyCell.HasValue)
                {
                    grid.AddGameObject(nearestEmptyCell.Value, selectedGameObject);
                }
                else
                {
                    grid.AddGameObject(initialPosition, selectedGameObject);
                }
                selectedGameObject = null;
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
