using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static float speed = 10f; //Controla a velocidade do jogo
    public static float TimeToSpawn = 3f; //Velocidade de spawn
    public static float score = 0f; //Pontuação
    public static string playerName = "Runner";
    public static string highscoreName = "Runner HighScore";
    public static float highScore = 0f;
    public static bool gameOver = false; //Controla o estado do game
    // Start is called before the first frame update

    public static void LoadData() { //Carrega os dados salvos
        GameController.highScore = PlayerPrefs.GetFloat("HighScore",0f);
        GameController.highscoreName = PlayerPrefs.GetString("HighScoreName", "Player");

    }
    public static void SaveData() { //Salva os dados salvos
        if(GameController.score > GameController.highScore) {
            GameController.highScore = GameController.score;
            GameController.highscoreName = GameController.playerName;
            PlayerPrefs.SetFloat("HighScore", GameController.highScore);
            PlayerPrefs.SetString("HighScoreName", GameController.highscoreName);
            PlayerPrefs.Save();
        }
        
    }
    void Start()
    {
        StartGame();
   
    }
    void Update() {
        
    }
    private void StartGame() {
        GameController.LoadData();
        GameController.speed = 10f;
        GameController.TimeToSpawn = 3f;
        GameController.score = 0f;
        GameController.gameOver = false;
        InvokeRepeating("ChangeDificulty", 1f, 5f);
        InvokeRepeating("ScoreBoard", 0.2f, 0.1f);
    }
    private void ChangeDificulty() {
        GameController.speed += 1;
        if (GameController.TimeToSpawn >= 1.5f) {
            GameController.TimeToSpawn -= 0.2f;
            
        }
    }
    private void ScoreBoard() {
        if(gameOver == false) {
            GameController.score += 0.05f * GameController.speed;
        }
        
    }
}
