using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    //public GameObject objectPrefab;  //kdyû je tohle zakomentovan˝ tak ty if projdou vûdy, aù je to false nebo true. Kdyû to odkomentujeö, tak neprojdou nikdy

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    World world; //moûnost vÌce level˘/svÏt˘
    int x;
    int y;

    // Empty constructor required by MonoBehaviour
    private void Awake()
    {
    }

    public void Initialize(World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }

    public bool building = false;

    public void OnMouseEnter()
    {
        if (building)
        {
            Debug.Log("sdtdfgdgfsgdfsgfdg");
            spriteRenderer.color = Color.green;
        }
    }

    public void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }

    public void OnMouseDown()
    {
        if (building)
        {
            //PlaceObjectOnTile(this.x, this.y, 1, 1);
            building = false;
        }
    }
/*
    public void PlaceObjectOnTile(int startX, int startY, int width, int height)
    {
        GameObject object_go = Instantiate(objectPrefab);

        float centerX = startX + (width - 1) / 2.0f;
        float centerY = startY + (height - 1) / 2.0f;

        object_go.transform.position = new Vector3(centerX, centerY, -1);
        object_go.transform.localScale = new Vector3(width, height, 1);
    }
    */
}


//ten krump·Ë m· komponent event trigger, tam je propojenej tile skript a je tam specifikovan˝, ûe to promÏnÌ bool na true