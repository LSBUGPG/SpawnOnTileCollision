using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

[System.Serializable]
public class TileEvent : UnityEvent<Vector3Int, Collider2D> {}

public class TileCollision : MonoBehaviour
{
    public TileBase tile;
    public Vector2 collisionOffset = Vector2.down * 0.5f;
    public TileEvent onCollision;
    Tilemap map;
    List<ContactPoint2D> contacts = new List<ContactPoint2D>();
    List<Vector3Int> collisions = new List<Vector3Int>();

    void Awake()
    {
        map = GetComponent<Tilemap>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        collisions.Clear();
        collision.GetContacts(contacts);
        foreach (var contact in contacts)
        {
            Vector2 position = contact.point + collisionOffset;
            Vector3Int coordinate = map.WorldToCell(position);
            if (!collisions.Contains(coordinate))
            {
                collisions.Add(coordinate);
            }
        }
        ProcessCollisions(collision.collider);
    }

    void ProcessCollisions(Collider2D collider)
    {
        foreach (Vector3Int coordinate in collisions)
        {
            if (map.GetTile(coordinate) == this.tile)
            {
                onCollision.Invoke(coordinate, collider);
            }
        }
    }
}
