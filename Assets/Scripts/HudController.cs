using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Text score;
    public Text scoreB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score != null) {
            score.text = "SCORE: " + ((int)GameController.score).ToString();
            scoreB.text = "SCORE: " + ((int)GameController.score).ToString();
        }
    }
}
