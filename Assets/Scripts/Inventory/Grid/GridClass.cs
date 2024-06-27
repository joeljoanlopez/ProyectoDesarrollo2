using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClass<T>
{
    private int width;
    private int height;
    private float cellSize;
    private T[,] gridArray;
    private TextMesh[,] textMeshArray;
    private GameObject[,] gameObjectArray;
    private Vector3 originPosition;

    public GridClass(int width, int height, float cellSize, Vector3 originPosition = default(Vector3))
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];
        textMeshArray = new TextMesh[width, height];
        gameObjectArray = new GameObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                textMeshArray[x, y] = WorldText.CreateWorldText(gridArray[x, y]?.ToString(), null, GetWorldPoint(x, y) + new Vector3(cellSize, cellSize) * 0.5f, 5, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPoint(x, y), GetWorldPoint(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPoint(x, y), GetWorldPoint(x + 1, y), Color.white, 100f);
            }
        }
    }

    private Vector3 GetWorldPoint(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, T value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            textMeshArray[x, y].text = value.ToString();
        }
        else
        {
            Debug.LogWarning($"SetValue: Index out of range. x: {x}, y: {y}");
        }
    }

    public void SetValue(Vector3 worldPosition, T value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public void AddGameObject(Vector3 worldPosition, GameObject gameObjectPrefab)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            if (gameObjectArray[x, y] != null)
            {
                // Destroy the existing GameObject before adding a new one
                GameObject.Destroy(gameObjectArray[x, y]);
            }
            Vector3 position = GetWorldPoint(x, y) + new Vector3(cellSize, cellSize) * 0.5f;
            gameObjectArray[x, y] = GameObject.Instantiate(gameObjectPrefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"AddGameObject: Index out of range. x: {x}, y: {y}");
        }
    }

    public GameObject GetGameObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gameObjectArray[x, y];
        }
        return null;
    }

    public bool IsEmpty(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gameObjectArray[x, y] == null;
        }
        return false;
    }

    public void RemoveGameObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            if (gameObjectArray[x, y] != null)
            {
                GameObject.Destroy(gameObjectArray[x, y]);
                gameObjectArray[x, y] = null;
            }
        }
    }

public Vector3? FindNearestEmptyCell(Vector3 worldPosition)
{
    int startX, startY;
    GetXY(worldPosition, out startX, out startY);

    float minDistance = float.MaxValue;
    Vector3? nearestEmptyCell = null;

    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            if (IsEmpty(x, y))
            {
                Vector3 cellPosition = GetWorldPoint(x, y) + new Vector3(cellSize, cellSize) * 0.5f;
                float distance = Vector3.Distance(worldPosition, cellPosition);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEmptyCell = cellPosition;
                }
            }
        }
    }

    return nearestEmptyCell;
}
}


public static class WorldText
{
    // Create Text in the World
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 10, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 0)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    // Create Text in the World
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}
