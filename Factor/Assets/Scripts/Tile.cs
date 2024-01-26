using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public enum TileType { Empty, Floor};

    TileType type = TileType.Empty;

    //Nìco do budoucna
    LooseObject looseObjcet; //tohle jsou random itemy na zemi
    InstalledObject installedObjcet; // tohle jsou vìci co placeneš jako tøeba dveøe nebo podávcí pás

    World world; //možnost více levelù/svìtù
    int x;
    int y;

    public Tile( World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }
}
