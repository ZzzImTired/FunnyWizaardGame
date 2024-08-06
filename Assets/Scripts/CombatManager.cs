using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    bool isPlayerTurn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void StartTurn()
    {
        if(isPlayerTurn == true)
        {
            //Do player turn
        }else{
            //Do enemy turn
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
