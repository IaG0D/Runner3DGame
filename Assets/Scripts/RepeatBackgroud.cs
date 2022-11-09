using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroud : MonoBehaviour
{
    private Vector3 startPosition; //pos inicial do fundo
    private float repeatWitdh;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWitdh = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatWitdh) {
            transform.position = startPosition;
        }
    }
}
