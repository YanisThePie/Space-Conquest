using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text EnnemiesCount;
    public Text LevelTimeText;
    GameObject Player;
    public GameObject VictoryScreen;
    int enemiesLeft;
    bool killedAllEnemies = false;
    float LevelTime;
    int cpt;

    void Start()
    {
        cpt = 0;
        enemiesLeft = 5;
        LevelTime = 0;
        
    }

    void FixedUpdate()
    {
        LevelTime += Time.deltaTime;
        SetCountEnnemies();
        if (enemiesLeft == 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        VictoryScreen.SetActive(true);
        if (cpt == 0)
            LevelTimeText.text = "TIME :" + ((double)Mathf.Round(LevelTime)).ToString() + "s";
        Player = GameObject.FindWithTag("Player");
        Player.GetComponent<CameraController>().enabled = false;
        var anim = GetComponent<Animator>();
        anim.enabled = false;
        cpt++;
    }

    void SetCountEnnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ennemy");
        enemiesLeft = enemies.Length;
        EnnemiesCount.text = "Ennemies Remaining " + enemies.Length.ToString();
    }

}
