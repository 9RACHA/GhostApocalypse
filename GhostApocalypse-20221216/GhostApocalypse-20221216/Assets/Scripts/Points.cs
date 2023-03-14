using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {
    float timeToLive = 1.2f;
    float speed = 2.5f;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start() {
        velocity = Vector3.up * speed;        
    }

    // Update is called once per frame
    void Update() {
        transform.position += velocity * Time.deltaTime;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color spriteColor = spriteRenderer.color;
        //Reduzco el canal alfa de spriteColor, en la cantidad que corresponde al 
        //deltaTime de este frame
        spriteColor.a -= Time.deltaTime/timeToLive;
        //Asigno el nuevo valor de color si no he alcanzado la invisibilidad
        if(spriteColor.a > 0) {
            spriteRenderer.color = spriteColor;
        } else {
            Destroy(gameObject);
        }


    }
}
