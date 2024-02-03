using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    private Dictionary<Vector2, Tile> tiles;

    public ObjectPlacer objectPlacer;
    private ObjectPlacer.Dir dir = ObjectPlacer.Dir.Down;
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
                tile.gameObject.SetActive(tilesVisible);
        }


        if (Input.GetKeyDown(KeyCode.F) && objectPlacer.building && objectPlacer.placeble)
        {
            if (Input.GetKeyDown(KeyCode.R))
                dir = ObjectPlacer.GetNextDir(dir);

            objectPlacer.PlaceObjectOnTile(1, 1, objectPlacer.GetRotationAngle(dir));
        }
        if (Input.GetKeyDown(KeyCode.Escape) && objectPlacer.building)
            objectPlacer.Building(); 
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < world.width; x++)
        {
            for (int y = 0; y < world.height; y++)
            {
                int randomInt = UnityEngine.Random.Range(1, 101);
                if (randomInt == 100)
                {
                    // Adjust cluster size and probability as needed
                    int clusterSize = UnityEngine.Random.Range(1, 10);
                    int clusterProbability = 30;

                    if (UnityEngine.Random.Range(1, 101) <= clusterProbability)
                    {
                        for (int offsetX = 0; offsetX < clusterSize; offsetX++)
                        {
                            for (int offsetY = 0; offsetY < clusterSize; offsetY++)
                            {
                                int clusterX = x + offsetX;
                                int clusterY = y + offsetY;

                                if (clusterX < world.width && clusterY < world.height)
                                {
                                    var spawnedTile = Instantiate(copperTile, new Vector3(clusterX, clusterY, 1), Quaternion.identity);
                                    spawnedTile.name = $"Tile {clusterX} {clusterY}";
                                    spawnedTile.Initialize(world, clusterX, clusterY);

                                    tiles[new Vector2(clusterX, clusterY)] = spawnedTile;
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    public void CameraGenerate()
    {
        tiles = new Dictionary<Vector2, Tile>();

        // Get the camera component
        Camera mainCamera = Camera.main;

        // Calculate the camera's position
        Vector3 cameraPosition = mainCamera.transform.position;

        // Generate tiles dynamically
        for (float x = cameraPosition.x - mainCamera.orthographicSize * mainCamera.aspect; x <= cameraPosition.x + mainCamera.orthographicSize * mainCamera.aspect; x++)
        {
            for (float y = cameraPosition.y - mainCamera.orthographicSize; y <= cameraPosition.y + mainCamera.orthographicSize; y++)
            {
                Vector2 tilePosition = new Vector2(x, y);

                // Check if the tile already exists
                if (!tiles.ContainsKey(tilePosition) && !TileExistsAtPosition(tilePosition))
                {
                    Tile spawnedTile = null;
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