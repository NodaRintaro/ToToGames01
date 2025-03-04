using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileType", menuName = "Scriptable Objects/TileType")]
public class TileType : ScriptableObject
{
    [SerializeField, Header("���s�\��Tile")]
    private List<TileBase> _walkableTile = new();

    public List<TileBase> WalkableTiles => _walkableTile;
}
