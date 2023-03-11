using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    GameObject playerGO;
    PlayerController playerScript;
    bool isObstaclesUsed;

    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerGO.GetComponent<PlayerController>();
        isObstaclesUsed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&& isObstaclesUsed==false)
        {
            playerScript.TouchToObsticle();
            isObstaclesUsed = true;
        }
    }
}
