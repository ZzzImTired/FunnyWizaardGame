using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 position = new Vector2();


    // Start is called before the first frame update
    void Start()
    {
        
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
        List<Vector2> output = new();
        Queue<Tuple<Vector2, int>> queue = new();

        queue.Enqueue(new Tuple<Vector2, int>(position, 0));


        while(queue.Count != 0){
            Tuple<Vector2, int> curPos = queue.Dequeue();



        }

        return output;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
