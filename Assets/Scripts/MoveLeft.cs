using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        if (!GameController.gameOver) {
            transform.Translate(Vector3.left * GameController.speed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject, 0.5f);
    }
}
