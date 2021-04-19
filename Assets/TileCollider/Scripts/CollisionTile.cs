using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionTile
{
    public Collider2D collider;
    public Tilemap tilemap;
    public Vector3Int coordinate;
    public TileBase tile;

    public CollisionTile(Collider2D col, Tilemap map, Vector3Int coord)
    {
        collider = col;
        tilemap = map;
        coordinate = coord;
        tile = map.GetTile(coord);
    }
}
