using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject objectPrefab;

    public void PlaceObjectOnTile(int startX, int startY, int width, int height)
    {
        GameObject object_go = Instantiate(objectPrefab);

        float centerX = startX + (width - 1) / 2.0f;
        float centerY = startY + (height - 1) / 2.0f;

        object_go.transform.position = new Vector3(centerX, centerY, -1);
        object_go.transform.localScale = new Vector3(width, height, 1);
    }
}
