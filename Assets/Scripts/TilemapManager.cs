using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public static TilemapManager singleton;

    [SerializeField] Tilemap highlightMap;
    [SerializeField] Tile highlightTile;
    
    void Awake(){
        if(singleton != null && singleton != this){
            Destroy(gameObject);
        } else {
            singleton = this;
        }
    }

    public void Highlight(List<Vector2Int> vector2s)
    {
        foreach (Vector2Int cur in vector2s)
        {
            highlightMap.SetTile((Vector3Int)(cur), highlightTile);
        }
    }
}
