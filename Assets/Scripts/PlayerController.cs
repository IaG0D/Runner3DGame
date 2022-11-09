using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody playerRG;
    public bool isonGround = true; //Se está tocando o chão ou não

    public float jumpForce = 10f; //Força do pulo
    public float gravityModifier = 1f; //Força da gravidade
    
    // Start is called before the first frame update
    void Start() {
        playerRG = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once pesr frame
    void Update() {
        float space = Input.GetAxis("Jump");
        if (space!=0 && isonGround == true && !GameController.gameOver) {
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isonGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision) {
        isonGround = true;
        if (collision.gameObject.name.StartsWith("Obstacle")) {
            GameController.gameOver = true;
        }
    }

}
