using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    Vector2Int position = new Vector2Int();
    int speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        List<Vector2Int> test = GetAvailableCoords();
        TilemapManager.singleton.Highlight(test);
    }
    public void MovePlayer(int x, int y)
    {
        position = new Vector2Int(x ,y);

        float newX = x + .5f;
        float newY = y + .5f;
        transform.position = new Vector3(newX, newY, 0);
    }

    private List<Vector2Int> GetAvailableCoords()
    {
        Vector2Int[] directions = {Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right, 
        new(-1, 1), new(1, 1), new(-1, -1), new(1, -1)};

        List<Vector2Int> output = new();
        Queue<Tuple<Vector2Int, int>> queue = new();

        queue.Enqueue(new Tuple<Vector2Int, int>(position, 0));


        while(queue.Count != 0){
            Tuple<Vector2Int, int> curPos = queue.Dequeue();
            if(curPos.Item2 > speed || output.Contains(curPos.Item1)) { continue; }

            output.Add(curPos.Item1);

            foreach (var curDir in directions)
            {
                Vector2Int curPosHolder = curPos.Item1 + curDir;
                queue.Enqueue(new Tuple<Vector2Int, int>(curPosHolder, curPos.Item2 + 1));
            }
        }

        return output;
    }
}
