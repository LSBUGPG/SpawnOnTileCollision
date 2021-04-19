using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnTile : MonoBehaviour
{
    public TileBase tile;
    public Vector3Int offset = Vector3Int.up;
    Tilemap map;

    void Awake()
    {
        map = GetComponent<Tilemap>();
    }

    public void OnCollision(Vector3Int coordinate, Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Vector3Int spawnCoordinate = coordinate + offset;
            if (map.GetTile(spawnCoordinate) != tile)
            {
                map.SetTile(spawnCoordinate, tile);
            }
        }
    }
}
