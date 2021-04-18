using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnOnCollision : MonoBehaviour
{
    public string collisionTag;
    public Tilemap map;
    public Vector2 collisionOffset = Vector2.down * 0.5f;
    public Tile tile;
    public Tile spawnTile;
    public Vector3Int spawnOffset;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(collisionTag))
        {
            TilemapCollider2D collider = collision.otherCollider as TilemapCollider2D;
            if (collision.contactCount > 0)
            {
                Vector3Int coordinate = map.WorldToCell(collision.GetContact(0).point + collisionOffset);
                TileBase tile = map.GetTile(coordinate);
                TileBase spawnTile = map.GetTile(coordinate + spawnOffset);
                // if (tile.sprite == this.tile.sprite && spawnTile.sprite != this.spawnTile.sprite)
                // {
                //     map.SetTile(coordinate + spawnOffset, this.spawnTile);
                // }
            }
        }
    }
}
