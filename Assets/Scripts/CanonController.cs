using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] private GameObject _canonBallGO;
    [SerializeField] private Transform _canonSpawnTransform;

    [SerializeField] private float _canonBallSpeed;
    bool isShootingOn;
    void Start()
    {
        isShootingOn = true;
        StartCoroutine(Shooting());
    }

 

    IEnumerator Shooting(){
        float delayTime = Random.Range(.5f, 1.5f);
         while (isShootingOn)
            {
            yield return new WaitForSeconds(delayTime);
            shoot();
            yield return new WaitForSeconds(1.5f);
            }
	}
    private void shoot()
    {
        GameObject cannonBall = Instantiate(_canonBallGO,_canonSpawnTransform.position,Quaternion.identity);
        Rigidbody canonRB = cannonBall.GetComponent<Rigidbody>();
        canonRB.velocity = -transform.forward * _canonBallSpeed;
    }
}
