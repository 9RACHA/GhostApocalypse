using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour {
    private float speed = 8f;

    //Límites del movimiento vertical
    private float maxY = 4;
    private float minY = -4;

    //usada para controlar la respuesta a las flechas arriba y abajo
    //según el movimiento que *ya* tiene la plataforma
    private int movementDirection;  
    // Start is called before the first frame update
    void Start() {
        movementDirection = 0;        
    }

    // Update is called once per frame
    void Update() {
        if(GameController.instance.GameOver) {
            return;
        }

        Vector3 velocity = Vector3.zero;

        if(Input.GetKey(KeyCode.UpArrow) && movementDirection != -1) {
            velocity = Vector3.up * speed;
            movementDirection = 1;
        } else if(Input.GetKey(KeyCode.DownArrow) && movementDirection != 1) {
            velocity = Vector3.down * speed;
            movementDirection = -1;
        } else {
            movementDirection = 0;
        }

        Vector3 newPosition = transform.position;
        newPosition += velocity * Time.deltaTime;
        //Ajustamos la posición en el eje vertical entre el mínimo y el máximo permitidos
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
}
