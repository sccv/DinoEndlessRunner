using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private Text score;
    [SerializeField]
    private Text highScore;

    private float scoreCount;
    public float ScoreCount 
    {
        get
        {
            return scoreCount;
        }
        set
        {
            scoreCount = value;
        } 
    }     
    private float highScoreCount;

    public float pointPerSecond;
    private bool scoreIncreasing;
    public bool ScoreIncreasing 
    {
        set
        {
            scoreIncreasing = value;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;

        highScoreCount = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetFloat("HighScore") : 0;

        scoreIncreasing = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player = FindObjectOfType<Player>();

        if (player.IsRunning && scoreIncreasing)
            scoreCount += pointPerSecond * Time.deltaTime;

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        score.text = "Score: " + Mathf.Round(scoreCount);
        highScore.text = "High Score: " + Mathf.Round(highScoreCount);

    }
}
