using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCollider : MonoBehaviour
{
    public float overlap = 0.1f;
    Tilemap map;
    Dictionary<Collider2D, Vector3Int> colliders =
        new Dictionary<Collider2D, Vector3Int>();

    void Awake()
    {
        map = GetComponent<Tilemap>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Vector3Int coordinate = GetCoordinate(collision);
        Debug.Assert(
            !colliders.ContainsKey(collider),
            $"Collider already contains {collider}");

        colliders[collider] = coordinate;

        SendMessage(
            "OnCollisionEnterTile",
            new CollisionTile(collider, map, coordinate),
            SendMessageOptions.DontRequireReceiver);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Debug.Assert(
            colliders.ContainsKey(collider),
            $"Collider doesn't contain {collider}");

        Vector3Int coordinate = colliders[collider];
        colliders.Remove(collider);

        SendMessage(
            "OnCollisionExitTile",
            new CollisionTile(collider, map, coordinate),
            SendMessageOptions.DontRequireReceiver);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Debug.Assert(
            colliders.ContainsKey(collider),
            $"Collider doesn't contain {collider}");

        Vector3Int previous = colliders[collider];
        Vector3Int coordinate = GetCoordinate(collision);
        if (previous == coordinate)
        {
            SendMessage(
                "OnCollisionStayTile",
                new CollisionTile(collider, map, coordinate),
                SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            SendMessage(
                "OnCollisionExitTile",
                new CollisionTile(collider, map, previous),
                SendMessageOptions.DontRequireReceiver);

            SendMessage(
                "OnCollisionEnterTile",
                new CollisionTile(collider, map, coordinate),
                SendMessageOptions.DontRequireReceiver);
        }
    }

    Vector3Int GetCoordinate(Collision2D collision)
    {
        Vector2 position = collision.transform.position;
        Vector2 closest = collision.otherCollider.ClosestPoint(position);
        Vector2 offset = closest - position;
        float length = offset.magnitude;
        if (length > 0.0)
        {
            length += overlap;
            offset.Normalize();
        }
        return map.WorldToCell(position + offset * length);
    }
}
