using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    GameObject playerGO;
    PlayerController playerController;
    bool isItCollected;

    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerController = playerGO.GetComponent<PlayerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&& isItCollected==false)
        {
            isItCollected = true;
            playerController.TouchToDiamond();
            Destroy(gameObject);
        }
    }
}
