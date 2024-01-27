using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    World world; //možnost více levelù/svìtù
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

    private void OnMouseEnter()
    {
        spriteRenderer.color = Color.green;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }

}
