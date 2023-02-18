using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameOverScript gameOver;
    public PlayerPanel playerPanel;

    public void gameOverRun(string title)
    {
        PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        gameOver.Setup(title, player.hasLost);
        playerPanel.setUp();
    }

    public void gameRestart()
    {
        gameOver.SetupOff();
        playerPanel.setUpOff();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
