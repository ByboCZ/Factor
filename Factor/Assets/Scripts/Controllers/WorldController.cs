using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    World world;
    public Sprite floorSprite;

    bool tilesVisible = true;

    // List pro uchov�v�n� v�ech SpriteRenderers
    List<SpriteRenderer> tileRenderers = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        world = new World();

        // Vytvo��m gameObject, kter� vizu�ln� uk�e tiles
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

                // P�id�n� SpriteRenderer do listu
                tileRenderers.Add(tile_sr);
            }
        }
    }

    void Update()
    {
        // Sledov�n� stisknut� kl�vesy E
        if (Input.GetKeyDown(KeyCode.E))
        {
            tilesVisible = !tilesVisible;

            // Nastaven� viditelnosti pro v�echny SpriteRenderers v listu
            foreach (SpriteRenderer tileRenderer in tileRenderers)
            {
                tileRenderer.enabled = tilesVisible;
            }
        }
    }
}
