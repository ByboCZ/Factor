﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    private Dictionary<Vector2, Tile> tiles;

    public ObjectPlacer objectPlacer;
    public Tile tilePrefab;
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
        if (Input.GetKeyDown(KeyCode.F) && objectPlacer.building)
        {
            objectPlacer.PlaceObjectOnTile(2, 2);
        }
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < world.width; x++)
        {
            for (int y = 0; y < world.height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Initialize(world, x, y);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}