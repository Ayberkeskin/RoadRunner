using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 5f;
    float movingSidesSpeed = 0.2f;
    Vector3 firstPos;
    Vector3 lastPos;
    float maxXPosition = 4.35f;
    bool isPlayerMoveing;

    float maxPlayerScale = 2.5f;
    float minPlayerScale = .8f;
    float diamondValue = .2f;
    float trapDamageValue = .3f;

   [SerializeField] GameObject particleDia;
   [SerializeField] GameObject particleObstical;

    private Animator PlayerAC;


    private void Start()
    {
        PlayerAC = GetComponent<Animator>();
    }
    void Update()
    {
        PlayerMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            isPlayerMoveing = false;
            StartIdleAnimation();
            GameManager.instance.ShowSuccesMenuPanel();
        }
        if (other.tag == "CannonBall")
        {
            if (isPlayerMoveing==true)
            {
                GetSmaller();
                ParticleObstical();
                Destroy(other.gameObject);
            }
        }

    }


    private void PlayerMove()
    {
        if (isPlayerMoveing==false)
        {
            return;
        }
        float xValue = 0;
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            lastPos = Input.mousePosition;
            float diffrences = lastPos.x - firstPos.x;
            xValue = diffrences * movingSidesSpeed;
        }
        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            lastPos = Vector3.zero;
            xValue = 0;
        }
        transform.Translate(xValue * Time.deltaTime, 0, playerSpeed * Time.deltaTime);
        float newXValue = Mathf.Clamp(transform.position.x, -maxXPosition, maxXPosition);
        transform.position = new Vector3(newXValue, transform.position.y, transform.position.z);
    }

    public void TouchToDiamond()
    {
        GetBigger();
        ParticleDia();
    }

    public void TouchToObsticle()
    {
       GetSmaller();
       ParticleObstical();
    }

    private void ParticleDia()
    {
        Vector3 effectPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        GameObject partical=  Instantiate(particleDia, effectPosition,Quaternion.identity);
        Destroy(partical,2f);
    }
    private void ParticleObstical()
    {
        Vector3 obsticleEffectPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject obsticalpartical = Instantiate(particleObstical, obsticleEffectPosition, Quaternion.identity);
        Destroy(obsticalpartical, 2f);
    }

    private void GetBigger()
    {
        transform.localScale = new Vector3(transform.localScale.x+diamondValue, transform.localScale.y + diamondValue, transform.localScale.z + diamondValue);
        if (transform.localScale.x>maxPlayerScale)
        {
            transform.localScale = new Vector3(maxPlayerScale, maxPlayerScale, maxPlayerScale);
        }
    }

    private void GetSmaller()
    {
        transform.localScale = new Vector3(transform.localScale.x - trapDamageValue, transform.localScale.y - trapDamageValue, transform.localScale.z - trapDamageValue);
        if (transform.localScale.x<minPlayerScale)
        {
            transform.localScale = new Vector3(minPlayerScale, minPlayerScale, minPlayerScale);
            StopPlayerMoveing(); 
            GameManager.instance.ShowFailMenu();
        }
    }
    private void StopPlayerMoveing()
    {
        isPlayerMoveing = false;
        StartIdleAnimation();
    }
    public void StartPlayerMoveing()
    {
        isPlayerMoveing = true;
        StartRunAnimation();
    }


    private void StartRunAnimation()
    {
        PlayerAC.SetBool("isPlayerRunning", true);
    }

    private void StartIdleAnimation()
    {
        PlayerAC.SetBool("isPlayerRunning", false);
    }
}
