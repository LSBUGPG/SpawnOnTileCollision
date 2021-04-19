using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnGrass : MonoBehaviour
{
    public TileBase ground;
    public TileBase grass;
    public Vector3Int offset = Vector3Int.up;
    Tilemap map;

    void Awake()
    {
        map = GetComponent<Tilemap>();
    }

    public void OnCollisionEnterTile(CollisionTile collision)
    {
        Collider2D collider = collision.collider;
        if (collider.CompareTag("Player") && collision.tile == ground)
        {
            Vector3Int coordinate = collision.coordinate + offset;
            if (collision.tile != grass)
            {
                map.SetTile(coordinate, grass);
            }
        }
    }
}
