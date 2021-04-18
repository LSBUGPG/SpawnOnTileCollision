using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu()]
public class Ground : TileBase
{
    public GameObject prefab;

    public override void GetTileData(Vector3Int position, ITilemap map, ref TileData data)
    {
        base.GetTileData(position, map, ref data);
        Debug.Log($"{data.sprite}");
        data.gameObject = prefab;
        Debug.Log($"{data.gameObject}");
    }
}
