using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    World world;
    public Sprite floorSprite;

    bool tilesVisible = true;

    // List pro uchovávání všech SpriteRenderers
    List<SpriteRenderer> tileRenderers = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        world = new World();

        // Vytvoøím gameObject, který vizuálnì ukáže tiles
        for (int x = 0; x < world.width; x++)
        {
            for (int y = 0; y < world.height; y++)
            {
                Tile tile_data = world.GetTileAt(x, y);

                GameObject tile_go = new GameObject();
                tile_go.name = "Tile_" + x + "_" + y;
                tile_go.transform.position = new Vector3(x, y, 0);
                tile_go.tag = "Tiles";

                SpriteRenderer tile_sr = tile_go.AddComponent<SpriteRenderer>();
                tile_sr.sprite = floorSprite;

                // Pøidání SpriteRenderer do listu
                tileRenderers.Add(tile_sr);
            }
        }
    }

    void Update()
    {
        // Sledování stisknutí klávesy E
        if (Input.GetKeyDown(KeyCode.E))
        {
            tilesVisible = !tilesVisible;

            // Nastavení viditelnosti pro všechny SpriteRenderers v listu
            foreach (SpriteRenderer tileRenderer in tileRenderers)
            {
                tileRenderer.enabled = tilesVisible;
            }
        }
    }
}
