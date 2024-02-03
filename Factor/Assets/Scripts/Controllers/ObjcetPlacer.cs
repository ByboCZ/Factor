using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    #region Variables
    public GameObject objectPrefab;

    public bool building = false;
    public bool placeble = false;

    public static Dir GetNextDir(Dir dir)
    {
        switch (dir)
        {
            default:
                case Dir.Down:  return Dir.Left;
                case Dir.Left:  return Dir.Up;
                case Dir.Up:    return Dir.Right;
                case Dir.Right: return Dir.Down;
        }
    }

    public enum Dir
    {
        Down, Up, Left, Right
    }
    #endregion

    private void Awake()
    {
        ObjectPlacerManager.Instance.CurrentObjectPlacer = this;
    }

    // Spawne objekt na curzoru myši
    public void PlaceObjectOnTile(int width, int height, int dir)
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        int mouseX = Mathf.RoundToInt(worldMousePosition.x);
        int mouseY = Mathf.RoundToInt(worldMousePosition.y);
        float centerX = mouseX + (width - 1) / 2.0f;
        float centerY = mouseY + (height - 1) / 2.0f;

        GameObject object_go = Instantiate(objectPrefab);

        object_go.transform.position = new Vector3(centerX, centerY, 1);
        object_go.transform.localScale = new Vector3(width, height, 1);
        object_go.transform.rotation = Quaternion.Euler(0, 0, dir);
    }

    public void Building() 
    {
        building = !building;
    } 
    public void Placeble(bool status)
    {
        placeble = status;
    }
    public int GetRotationAngle(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return 0;
            case Dir.Left: return 90;
            case Dir.Up: return 180;
            case Dir.Right: return 270;
        }
    }
}
