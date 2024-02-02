using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    #region Variables
    public GameObject objectPrefab;

    public bool building = false;
    public bool placeble = false;
    #endregion

    private void Awake()
    {
        ObjectPlacerManager.Instance.CurrentObjectPlacer = this;
    }

    // Spawne objekt na curzoru myši
    public void PlaceObjectOnTile(int width, int height)
    {
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Round to the nearest integer to get tile coordinates
        int mouseX = Mathf.RoundToInt(worldMousePosition.x);
        int mouseY = Mathf.RoundToInt(worldMousePosition.y);

        GameObject object_go = Instantiate(objectPrefab);

        float centerX = mouseX + (width - 1) / 2.0f;
        float centerY = mouseY + (height - 1) / 2.0f;

        object_go.transform.position = new Vector3(centerX - 1, centerY - 1, 1);
        object_go.transform.localScale = new Vector3(width, height, 1);
    }

    public void Building() 
    {
        building = !building;
        Debug.Log("Klik");
    } 
    public void Placeble(bool status)
    {
        placeble = status;
        Debug.Log("Status");
    } 
}
