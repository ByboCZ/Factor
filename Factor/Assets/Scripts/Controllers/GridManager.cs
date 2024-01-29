using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    private Dictionary<Vector2, Tile> tiles;

    public ObjectPlacer objectPlacer;
    public Tile tilePrefab;
    public Tile copperTile;
    World world;

    bool tilesVisible = true;
    #endregion

    void Start()
    {
        world = new World();
        GenerateGrid();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tilesVisible = !tilesVisible;
            objectPlacer.building = false;

            foreach (var tile in tiles.Values)
            {
                tile.gameObject.SetActive(tilesVisible);
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && objectPlacer.building && objectPlacer.placeble)
        {
            objectPlacer.PlaceObjectOnTile(2, 2);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && objectPlacer.building)
        {
            objectPlacer.Building();
        }       
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < world.width; x++)
        {
            for (int y = 0; y < world.height; y++)
            {
                int randomInt = UnityEngine.Random.Range(1, 101);
                if (randomInt == 90)
                {
                    var spawnedTile = Instantiate(copperTile, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.Initialize(world, x, y);

                    tiles[new Vector2(x, y)] = spawnedTile;
                }
                else
                {
                    var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.Initialize(world, x, y);

                    tiles[new Vector2(x, y)] = spawnedTile;
                }
            }
        }
    }

    public void CameraGenerate()
    {
        tiles = new Dictionary<Vector2, Tile>();

        // Get the camera component
        Camera mainCamera = Camera.main;

        // Calculate the camera's boundaries in world space
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        Vector3 cameraPosition = mainCamera.transform.position;

        float halfCameraWidth = cameraWidth / 2f;
        float halfCameraHeight = cameraHeight / 2f;

        // Calculate the visible area
        float visibleMinX = Mathf.Floor(cameraPosition.x - halfCameraWidth);
        float visibleMaxX = Mathf.Floor(cameraPosition.x + halfCameraWidth);
        float visibleMinY = Mathf.Floor(cameraPosition.y - halfCameraHeight);
        float visibleMaxY = Mathf.Floor(cameraPosition.y + halfCameraHeight);

        // Generate tiles dynamically
        for (float x = visibleMinX; x <= visibleMaxX; x++)
        {
            for (float y = visibleMinY; y <= visibleMaxY; y++)
            {
                Vector2 tilePosition = new Vector2(x, y);

                // Check if the tile already exists
                if (!tiles.ContainsKey(tilePosition) && !TileExistsAtPosition(tilePosition))
                {
                    int randomInt = UnityEngine.Random.Range(1, 101);
                    Tile spawnedTile = null;

                    if (randomInt == 90)
                    {
                        spawnedTile = Instantiate(copperTile, new Vector3(x, y), Quaternion.identity);
                    }
                    else
                    {
                        spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                    }

                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.Initialize(world, Mathf.FloorToInt(x), Mathf.FloorToInt(y));

                    tiles[tilePosition] = spawnedTile;
                }
            }
        }
    }


    bool TileExistsAtPosition(Vector2 position)
    {
        // Check if a tile already exists at the given position
        Collider2D collider = Physics2D.OverlapPoint(position);
        return collider != null && collider.GetComponent<Tile>() != null;
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}