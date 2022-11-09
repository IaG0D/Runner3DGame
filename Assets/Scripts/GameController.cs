using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static float speed = 10f; //Controla a velocidade do jogo
    public static float TimeToSpawn = 3f; //Velocidade de spawn
    public static float score = 0f; //Pontua��o
    public static bool gameOver = false; //Controla o estado do game
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
   
    }
    void Update() {
        
    }
    private void StartGame() {
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
