using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    #region Variables
    Tile[,] tiles;
    public int width;
    public int height;
    #endregion
    
    public World(int width = 100, int height = 100) //pouze defaultní hodnoty
    {
        this.width = width;
        this.height = height;

        tiles = new Tile[width, height];

        //naèítám celý herní svìt
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = new GameObject().AddComponent<Tile>();
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Initialize(this, x, y);

                tiles[x, y] = spawnedTile;
            }
        }

        Debug.Log("World created with " + (width*height) + " tiles.");
    }

    public Tile GetTileAt(int x, int y)
    {
        if(x > width || x < 0 || y > height || y < 0)
        {
            Debug.Log("Tile ("+x+","+y+") is out of range.");
            return null;
        }
        return tiles[x,y];
    }
}
