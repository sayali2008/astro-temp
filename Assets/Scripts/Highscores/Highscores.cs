using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    // Start is called before the first frame update
    public Text HighScore;
    public Text Rank;
    private string HighScoreText;
    private string RankText;
    void Start()
    {
        int i = 1;
        string s = PlayerPrefs.GetString("HighScores");
        String[] scores = s.Split(',');
        foreach(var score in scores) {
            if(Convert.ToInt32(score) < 0)
                break;
            HighScoreText += score + "\n";
            RankText += i + "\n";
            i += 1;
        }
        while(i <= 10) {
            RankText += i + "\n";
            HighScoreText += "--\n";
            i += 1;
        }
        HighScore.text = HighScoreText;
        Rank.text = RankText;
    }
}
