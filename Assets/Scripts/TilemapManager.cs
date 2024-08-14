using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public static TilemapManager singleton;
    internal bool IsWaiting {get; private set;}
    internal Vector2Int ClickLoc {get; private set;}

    [SerializeField] Tilemap highlightMap;
    [SerializeField] Tile highlightTile, mouseHighlightTile;
    
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
            highlightMap.SetTile((Vector3Int)cur, highlightTile);
        }
    }
    public IEnumerator WaitForClick(List<Vector2Int> vector2s)
    {
        IsWaiting = true;
        Vector3Int curPos = new Vector3Int();
        Highlight(vector2s);
        //Get the mouse position and convert it into a grid position
        while(IsWaiting)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3Int gridPosition = highlightMap.WorldToCell(worldPosition);

            //highlight the tile the mouse is on
            if(!curPos.Equals(gridPosition))
            {
                highlightMap.SetTile(curPos, vector2s.Contains((Vector2Int)curPos) ? highlightTile : null);
            }
            highlightMap.SetTile(gridPosition, vector2s.Contains((Vector2Int)gridPosition) ? mouseHighlightTile : null);
            curPos = gridPosition;
            if(Input.GetMouseButtonDown(0))
            {
                ClickLoc = (Vector2Int)curPos;
                IsWaiting = false;
            }

            yield return null;
        }
    }
}