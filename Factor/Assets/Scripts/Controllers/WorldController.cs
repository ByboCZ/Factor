using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    World world;
    public Sprite floorSprite;

    // Start is called before the first frame update
    void Start()
    {
        world = new World();

        //Vytvoøím gameObject, který vizuálnì ukáže tiles
        for (int x = 0; x < world.width; x++)
        {
            for (int y = 0; y < world.height; y++)
            {
                Tile tile_data = world.GetTileAt(x, y);

                GameObject tile_go = new GameObject();
                tile_go.name = "Tile_" + x + "_" + y;
                tile_go.transform.position = new Vector3(x, y, 0);

                SpriteRenderer tile_sr = tile_go.AddComponent<SpriteRenderer>();
                tile_sr.sprite = floorSprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
