using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security;

public class LogicScript : MonoBehaviour
{
    public Text scoreText;
    public int playerScore;
    public Vector3 startpos;
    

    void Start()
    {
        startpos = scoreText.transform.position;
    }

    public void addScore(int valueAdded)
    {
        string previousPlayerScore = playerScore.ToString();
        playerScore = playerScore + valueAdded;
        string playerScoreString = playerScore.ToString();
        if(playerScoreString.Length > previousPlayerScore.ToString().Length)
        {
            scoreText.rectTransform.sizeDelta = new Vector2(scoreText.rectTransform.sizeDelta.x + 25, scoreText.rectTransform.sizeDelta.y);
            scoreText.transform.position = new Vector3(scoreText.transform.position.x + 12, scoreText.transform.position.y, scoreText.transform.position.z);
            //GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.y + 25, GetComponent<RectTransform>().sizeDelta.y);
        }
        scoreText.text = playerScoreString;
    }

    public void setToNull()
    {
        scoreText.transform.position = startpos
            ;
        scoreText.rectTransform.sizeDelta = new Vector2(32.8647f, 46.6177f);
        
        playerScore = 0;
        scoreText.text = "0";
    }

}
