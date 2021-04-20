# Tile Collider

You can add the `TileCollider` component to a `Tilemap` object to send tile based collision messages to the object.

The `TileCollider` has one public property: `Overlap`. This property is the amount projected beyond the collision point for the purposes of finding the tile to collide with.

With this script attached to a Tilemap with a `Tilemap Collider 2D` and collision of a Collider2D with the tilemap will send the following messages to the object:

## Messages

- `OnCollisionEnterTile(CollisionTile collision)`
- `OnCollisionExitTile(CollisionTile collision)`
- `OnCollisionStayTile(CollisionTile collision)`

```csharp
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnGrass : MonoBehaviour
{
    public TileBase ground;
    public TileBase grass;
    public Vector3Int offset = Vector3Int.up;

    public void OnCollisionEnterTile(CollisionTile collision)
    {
        Collider2D collider = collision.collider;
        if (collider.CompareTag("Player") && collision.tile == ground)
        {
            Vector3Int coordinate = collision.coordinate + offset;
            if (collision.tile != grass)
            {
                collision.tilemap.SetTile(coordinate, grass);
            }
        }
    }
}
```
