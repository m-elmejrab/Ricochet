using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Text mainGameText;
    public Text scoreText;
    private SceneManager sceneManager;
    private float timeSpent = 0f;
    private bool startCount = true;
    


    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);


    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (startCount)
            timeSpent += Time.deltaTime;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = ((int)timeSpent).ToString();

    }

    public void GameOver(bool enemyAttacking)
    {
        startCount = false;
        //mainGameText = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        mainGameText = GameObject.Find("MainText").GetComponent<Text>();
        

        if (enemyAttacking)
            mainGameText.text = "You were hit by the Red Ball !! The Game will Restart Shortly";
        else
            mainGameText.text = "You couldn't hit the green Ball !! The Game will Restart Shortly";

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        player.SetActive(false);
        enemy.SetActive(false);
        Invoke("RestartLevel", 5f);

    }

    void RestartLevel()
    {
        timeSpent = 0;
        startCount = true;
        SceneManager.LoadScene("Main");
        mainGameText.text = "Hit";
    }

}
