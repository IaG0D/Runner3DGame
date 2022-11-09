using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
    public Text score;
    public Text scoreB;
    public Text highScore;
    public Text highScoreB;
    // Start is called before the first frame update
    void Start() {

        score.text = "Player: "+GameController.playerName+" , Score: " + ((int)GameController.score).ToString();
        scoreB.text = "Player: " +GameController.playerName+ " , Score: " + ((int)GameController.score).ToString();

        highScore.text = "Player: " +GameController.highscoreName+ " , HighScore: " + ((int)GameController.highScore).ToString();
        highScoreB.text = "Player: " +GameController.highscoreName+ " , HighScore: " + ((int)GameController.highScore).ToString();
        Invoke("GoMenu", 5f);
    }

    // Update is called once per frame
    void Update() {
        
    }
    void GoMenu() {
        SceneManager.LoadScene("Menu");
    }
}

