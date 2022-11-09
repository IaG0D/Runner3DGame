using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float speed = 10f; //Controla a velocidade do jogo
    public static float TimeToSpawn = 3f; //Velocidade de spawn
    public static float score = 0f; //Pontuação
    public static bool gameOver = false; //Controla o estado do game
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        
    }
    
    private void StartGame() {
        GameController.speed = 10f;
        GameController.TimeToSpawn = 3f;
        GameController.score = 0f;
        GameController.gameOver = false;
        InvokeRepeating("ChangeDificulty", 1f, 5f);
    }
    private void ChangeDificulty() {
        GameController.speed += 1;
        if (GameController.TimeToSpawn >= 1.5f) {
            GameController.TimeToSpawn -= 0.2f;
        }
    }
}
