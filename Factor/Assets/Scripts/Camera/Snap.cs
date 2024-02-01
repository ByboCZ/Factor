using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public Transform follow;
    public float snap;

    void Update()
    {
        Vector2 pos = new Vector2(Mathf.Round(follow.position.x / snap) * snap, Mathf.Round(follow.position.y / snap) * snap);
        transform.position = pos;
    }
}
