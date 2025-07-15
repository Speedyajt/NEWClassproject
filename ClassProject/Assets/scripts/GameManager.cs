using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public PlayerScript player;
    public float time;
    public bool timeActive;

    [Header("Game UI")]
    public TMP_Text gameUI_score;
    public TMP_Text gameUI_health;
    public TMP_Text gameUI_time;


    [Header("Countdown UI")]
    public TMP_Text countdownText;
    public int countdown;
    
    [Header("Screens")]
    public GameObject countdownUI;
    public GameObject gameUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("sir capsulote").GetComponent<PlayerScript>();
        time = 0;
        player.enabled = false;

        SetScreen(countdownUI);

        StartCoroutine(CountDownRoutine());
    }

    IEnumerator CountDownRoutine()
    {
        countdownText.gameObject.SetActive(true);
        countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;

        }
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        player.enabled = true;

        startGame();
    }   
    
    void startGame()
    {
        SetScreen(gameUI);
        timeActive = true;
    }

    public void endGame()
    {
        timeActive = false; 

        player.enabled = false;
    }
   

    // Update is called once per frame
    void Update()
    {
       if(timeActive)
        {
            time = time + Time.deltaTime;
        }

        gameUI_score.text = "Coins: " + player.coinCount;
        gameUI_score.text = "Health" + player.health;
        gameUI_time.text = "Time: " + (time * 1).ToString("f2");

    }

    public void SetScreen(GameObject screen)
    {
        gameUI.SetActive(false);
        countdownUI.SetActive(false);
        
        screen.SetActive(true);
    }
}
