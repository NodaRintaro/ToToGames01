using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private Grid _grid;

    [SerializeField] Tilemap _tilemap;

    [SerializeField,Header("タイルの種類分けされたデータクラス")]
    private TileType _tileType;

    private void Start()
    {
        _tilemap = FindAnyObjectByType<Tilemap>();
    }

    private void Update()
    {
        
    }

    private void PlayerMove()
    {

    }

    private bool CanWalkTile(Vector3Int posision)
    {
        TileBase tile = _tilemap.GetTile(posision);

        return IsWalkableTile(tile);
    }

    private bool IsWalkableTile(TileBase tile)
    {
        foreach (var walkableTile in _tileType.WalkableTiles)
        {
            if(tile == walkableTile) return true;
        }
        return false;
    }
}
