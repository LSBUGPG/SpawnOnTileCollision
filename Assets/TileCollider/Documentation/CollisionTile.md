# Collision Tile

Data passed to the collision functions:

- `OnCollisionEnterTile(CollisionTile collision)`
- `OnCollisionExitTile(CollisionTile collision)`
- `OnCollisionStayTile(CollisionTile collision)`

## Properties

| | |
|--|--|
| `collider` | The incoming `Collider2D` involved in the collision |
| `tilemap` | The tilemap with the `TilemapCollider2D` involved in the collision |
| `coordinate` | The index into the tilemap of the nearest tile to the collision |
| `tile` | The nearest `TileBase` tile to the collision |
