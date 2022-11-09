using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody playerRG;
    private Animator playerAnim; //Controla a animação
    public AudioSource playerJump;
    public AudioSource playerDeath;
    public ParticleSystem particulePlayer;
    public ParticleSystem particuleExplosion;
    public bool isonGround = true; //Se está tocando o chão ou não
    public float jumpForce = 10f; //Força do pulo
    public float gravityModifier = 1f; //Força da gravidade
    
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
            playerJump.Play();
            isonGround = false;
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

        }
    }

}
