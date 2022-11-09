using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody playerRG;
    private Animator playerAnim; //Controla a anima��o
    public AudioSource playerJump;
    public AudioSource playerDeath;
    public ParticleSystem particulePlayer;
    public ParticleSystem particuleExplosion;
    public bool isonGround = true; //Se est� tocando o ch�o ou n�o
    public float jumpForce = 10f; //For�a do pulo
    public float gravityModifier = 1f; //For�a da gravidade
    
    // Start is called before the first frame update
    void Start() {
        playerRG = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once pesr frame
    void Update() {
        float space = Input.GetAxis("Jump");
        if (space!=0 && isonGround == true && !GameController.gameOver) {
            isonGround = false;
            playerJump.Play();
            particulePlayer.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }
    private void OnCollisionEnter(Collision collision) {
        isonGround = true;
        particulePlayer.Play();
        if (collision.gameObject.name.StartsWith("Obstacle")) {
            playerDeath.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            GameController.gameOver = true;
            particulePlayer.Stop();
            particuleExplosion.Play();
            Invoke("GoGameOver", 5f);

        }
    }
    private void OnTriggerEnter(Collider other) {
        GameController.gameOver = true;
        playerDeath.Play();
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 2);
        GameController.gameOver = true;
        particulePlayer.Stop();
        particuleExplosion.Play();
        
    }
    void GoGameOver() {
        SceneManager.LoadScene("GameOver");
    }

}
