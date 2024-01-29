using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Variables
    private SpriteRenderer spriteRenderer;
    private ObjectPlacer objectPlacer;
    World world;

    int x;
    int y;
    #endregion

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectPlacer = ObjectPlacerManager.Instance.CurrentObjectPlacer;
    }

    public void Initialize(World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }

    public void OnMouseEnter()
    {
        if (objectPlacer != null && objectPlacer.building)
        {
            if(this.tag == "Resource")
            {
                spriteRenderer.color = Color.green;
                objectPlacer.Placeble(true);
            }
            else
            {
                spriteRenderer.color = Color.red;
                objectPlacer.Placeble(false);
            }
        }
    }

    public void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
}