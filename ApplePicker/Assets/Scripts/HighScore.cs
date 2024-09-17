using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    static private TextMeshProUGUI _UI_TEXT;

    static private int _SCORE = 1000;

    // reference to this GO's text component
    private TextMeshProUGUI txtCom;

    void Awake()
    {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();

        //if playerprefs highscore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        //assign the high score to the highscore
        PlayerPrefs.SetInt("HighScore", SCORE);

    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;

            PlayerPrefs.SetInt("HighScore", value);

            if ( _UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return; // if score is too low, return
        SCORE = scoreToTry;
    }

    // easily reset playerprefs highscore
    [Tooltip("Check this box to reset HighScore in PlayerPrefs")]

    public bool resetHighScoreNow = false;

    void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }
}
