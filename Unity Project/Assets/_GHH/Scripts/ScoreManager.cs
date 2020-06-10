using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private void Awake() => Instance = this;

    public Text scoreTxt;
    public Text highScoreTxt;
    public TextMeshProUGUI textTxt;


    int score = 0;
    int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTxt.text = "HighScore:" + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        SaveHighScore();
    }

    private void SaveHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreTxt.text = "HighScore" + highScore;
        }
    }

    public void AddScore()
    {
        score++;
        scoreTxt.text = "Score:" + score;

        textTxt.text = "test:" + score;
    }
}
