using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    // Start is called before the first frame update
    public void StartTurn()
    {
        playerMovement.OnStartTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
