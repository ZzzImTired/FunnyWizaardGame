using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 position = new Vector2();
    int speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        GetAvailableCoords();
    }
    public void MovePlayer(int x, int y)
    {
        position = new Vector2(x ,y);

        float newX = x + .5f;
        float newY = y + .5f;
        transform.position = new Vector3(newX, newY, 0);
    }

    private List<Vector2> GetAvailableCoords()
    {
        Vector2[] directions = {Vector2.up, Vector2.down, Vector2.left, Vector2.right, 
        new(-1, 1), new(1, 1), new(-1, -1), new(1, -1)};

        List<Vector2> output = new();
        Queue<Tuple<Vector2, int>> queue = new();

        queue.Enqueue(new Tuple<Vector2, int>(position, 0));


        while(queue.Count != 0){
            Tuple<Vector2, int> curPos = queue.Dequeue();
            if(curPos.Item2 > speed || output.Contains(curPos.Item1)) { continue; }

            output.Add(curPos.Item1);

            foreach (var curDir in directions)
            {
                Vector2 curPosHolder = curPos.Item1 + curDir;
                queue.Enqueue(new Tuple<Vector2, int>(curPosHolder, curPos.Item2 + 1));
            }
        }

        return output;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
