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
    private GridObject[,] gameObjectArray;
    private Vector3 originPosition;

    public GridClass(int width, int height, float cellSize, Vector3 originPosition = default(Vector3))
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];
        textMeshArray = new TextMesh[width, height];
        gameObjectArray = new GridObject[width, height];

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

    public void AddGameObject(Vector3 worldPosition, GameObject gameObjectPrefab, int sizeX = 1, int sizeY = 1)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        if (AreCellsEmpty(x, y, sizeX, sizeY))
        {
            Vector3 position = GetWorldPoint(x, y) + new Vector3(cellSize * sizeX, cellSize * sizeY) * 0.5f;
            GameObject gameObject = GameObject.Instantiate(gameObjectPrefab, position, Quaternion.identity);
            GridObject gridObject = new GridObject(gameObject, sizeX, sizeY);

            for (int i = x; i < x + sizeX; i++)
            {
                for (int j = y; j < y + sizeY; j++)
                {
                    gameObjectArray[i, j] = gridObject;
                }
            }
        }
        else
        {
            Debug.LogWarning($"AddGameObject: Not enough space for object at x: {x}, y: {y} with sizeX: {sizeX}, sizeY: {sizeY}");
        }
    }

    public void RemoveGameObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            GridObject gridObject = gameObjectArray[x, y];
            if (gridObject != null)
            {
                for (int i = x; i < x + gridObject.SizeX; i++)
                {
                    for (int j = y; j < y + gridObject.SizeY; j++)
                    {
                        if (i >= 0 && j >= 0 && i < width && j < height)
                        {
                            gameObjectArray[i, j] = null;
                        }
                    }
                }
                GameObject.Destroy(gridObject.GameObject);
            }
        }
    }

    public GridObject GetGameObject(Vector3 worldPosition)
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

    public bool AreCellsEmpty(int startX, int startY, int sizeX, int sizeY)
    {
        for (int x = startX; x < startX + sizeX; x++)
        {
            for (int y = startY; y < startY + sizeY; y++)
            {
                if (x < 0 || y < 0 || x >= width || y >= height || gameObjectArray[x, y] != null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public Vector3? FindNearestEmptyCell(Vector3 worldPosition, int sizeX = 1, int sizeY = 1)
    {
        float minDistance = float.MaxValue;
        Vector3? nearestEmptyCell = null;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (AreCellsEmpty(x, y, sizeX, sizeY))
                {
                    Vector3 cellPosition = GetWorldPoint(x, y) + new Vector3(cellSize * sizeX, cellSize * sizeY) * 0.5f;
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


   public class GridObject
{
    public GameObject GameObject { get; private set; }
    public int SizeX { get; private set; }
    public int SizeY { get; private set; }

    public GridObject(GameObject gameObject, int sizeX, int sizeY)
    {
        GameObject = gameObject;
        SizeX = sizeX;
        SizeY = sizeY;
    }

    public void Rotate()
    {
        // Swap sizeX and sizeY
        int temp = SizeX;
        SizeX = SizeY;
        SizeY = temp;

        // Rotate the game object 90 degrees
        GameObject.transform.Rotate(0, 0, 90);
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
