using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gamePanel;
    public GameObject succesMenu;
    public GameObject failPanel;

    private void Awake()
    {
        if (instance!=null&&instance!=this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public void StartButton()
    {
        gamePanel.SetActive(false);
        GameObject playerGo = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerScript = playerGo.GetComponent<PlayerController>();
        playerScript.StartPlayerMoveing();
    }

    public void ShowSuccesMenuPanel()
    {
        succesMenu.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowFailMenu()
    {
        failPanel.SetActive(true);
    }
}
