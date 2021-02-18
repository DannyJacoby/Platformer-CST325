using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private static readonly TimeSpan MinInterval = TimeSpan.FromSeconds(3);
    private readonly Stopwatch stopwatch = new Stopwatch(); // Stopped initially
    
    public float timeRemaining = 300f;
    
    private const int ScoreTextLength = 6;
    private const int CoinsTextLength = 3;
    private bool _timerIsRunning = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI worldMapText;
    public TextMeshProUGUI timeText;

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
            // Debug.Log("TIME'S UP");
            timeRemaining = 0;
            _timerIsRunning = false;
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
}
