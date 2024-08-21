using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    bool isPlayerTurn = true;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        StartTurn();
    }
    void StartTurn()
    {
        if(isPlayerTurn == true)
        {
            player.StartTurn();
        }else{
            //Do enemy turn
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
