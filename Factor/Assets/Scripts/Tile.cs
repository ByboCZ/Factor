using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public enum TileType { Empty, Floor};

    TileType type = TileType.Empty;

    //N�co do budoucna
    LooseObject looseObjcet; //tohle jsou random itemy na zemi
    InstalledObject installedObjcet; // tohle jsou v�ci co placene� jako t�eba dve�e nebo pod�vc� p�s

    World world; //mo�nost v�ce level�/sv�t�
    int x;
    int y;

    public Tile( World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }
}
