using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class UI_Manager : MonoBehaviour
{
    public GameObject Ethan;
    public LevelParserStarter lvlParser;
    private static readonly TimeSpan MinInterval = TimeSpan.FromSeconds(3);
    private readonly Stopwatch stopwatch = new Stopwatch(); // Stopped initially

    public float totalTime = 100;
    public float timeRemaining = 100f;
    
    private const int ScoreTextLength = 6;
    private const int CoinsTextLength = 3;
    private bool _timerIsRunning = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI worldMapText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI resultText;

    // Start is called before the first frame update
    void Start()
    {
        _timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && _timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            timeText.SetText("TIME\n" + Math.Floor(timeRemaining));
            
        }
        else if(_timerIsRunning)
        {
            timeRemaining = 0;
            _timerIsRunning = false;
            ResetTheGame(false);
        }
        
        if ( Math.Floor(totalTime - timeRemaining) >= 3)
        {
            // Debug.Log("TIMES UP");
            setResult(" ");
            resultText.color = Color.black;
        }
    }

    public void ScoreTracker(int scoreIn)
    {
        var scoreTextCurrent = scoreText.GetParsedText();
        var scoreString = scoreTextCurrent.Replace("MARIO", "");

        var scoreValue = int.Parse(scoreString) + scoreIn;

        var tempScoreLength = ScoreTextLength - scoreValue.ToString().Length;
        scoreString = "";
        for(var i = 0; i < tempScoreLength; i++)
        {
            scoreString += "0";
        }

        scoreString += scoreValue.ToString();
        
        scoreText.SetText("MARIO\n" + scoreString);
    }

    public void CoinTracker(int coinIn)
    {
        if (stopwatch.IsRunning && stopwatch.Elapsed < MinInterval)
        {
            return;
        }

        try
        {
            var coinText = coinsText.GetParsedText();
            var coinString = coinText.Replace("x", "");
            var coinValue = int.Parse(coinString) + coinIn;
            var tempCoinsLength = CoinsTextLength - coinValue.ToString().Length;

            coinString = "";
            for (var i = 0; i < tempCoinsLength; i++)
            {
                coinString += "0";
            }

            coinString += coinValue.ToString();
            
            coinsText.SetText("x" + coinString);
            
            ScoreTracker(100);
        }
        finally
        {
            stopwatch.Reset();
        }
    }

    public void updateWorldName(string worldName)
    {
        worldMapText.SetText(worldName);
    }

    public void setResult(string result)
    {
        resultText.SetText(result);
    }

    public void ResetTheGame(bool won)
    {
        string result = (won) ? "YOU WON" : "YOU LOST";
        setResult(result);
        resultText.color = (won) ? Color.green : Color.red;


        timeRemaining = 100f;
        timeText.SetText("TIME\n" + timeRemaining);
        _timerIsRunning = true;
        
        scoreText.SetText("MARIO\n000000");
        
        coinsText.SetText("x000");

        Ethan.transform.position = new Vector3(16f,2f,-0.5f);

        if (won)
        {
            lvlParser.RefreshParse();
        }
    }
}
