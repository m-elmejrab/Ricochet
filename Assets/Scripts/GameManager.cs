using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] Text mainGameText;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;
    private float timeSpent = 0f;
    private bool startCount = true;

    GameObject player;
    GameObject enemy;

    private void Start()
    {
        PrepareScene();
    }

    private void PrepareScene()
    {
        player = Instantiate(playerPrefab);
        enemy = Instantiate(enemyPrefab);
    }

    void FixedUpdate()
    {
        if (startCount)
            timeSpent += Time.deltaTime;
        scoreText.text = ((int)timeSpent).ToString();

    }

    public void GameOver(bool enemyAttacking)
    {
        startCount = false;

        if (enemyAttacking)
            mainGameText.text = "You were hit by the Red Ball !! The Game will Restart Shortly";
        else
            mainGameText.text = "You couldn't hit the green Ball !! The Game will Restart Shortly";


        Destroy(player);
        Destroy(enemy);
        Invoke("RestartLevel", 3.5f);

    }

    void RestartLevel()
    {
        timeSpent = 0;
        startCount = true;
        PrepareScene();
        mainGameText.text = "Hit";
    }

    public void UpdateGameText(bool shouldAttack, int time)
    {
        if (shouldAttack)
        {
            mainGameText.text = "Hit the green ball within " + time + " Seconds";
        }
        else
        {
            mainGameText.text = "Run from the red ball for " + time + " Seconds";
        }
    }



}
