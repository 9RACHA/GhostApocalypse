using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour {

    private float speed = 8f; // Velocidad de la barrera

    // Límites del movimiento vertical
    private float maxY = 4; // Límite superior
    private float minY = -4; // Límite inferior

    // Usada para controlar la respuesta a las flechas arriba y abajo
    // según el movimiento que *ya* tiene la plataforma
    private int movementDirection; 

    // Start is called before the first frame update
    void Start() {
        movementDirection = 0;        
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.GameOver) {
            return; // Si el juego ha terminado, no hacer nada
        }

        Vector3 velocity = Vector3.zero; // Velocidad inicial de la barrera (sin movimiento)

        // Verificar entrada del teclado para controlar el movimiento vertical
        if(Input.GetKey(KeyCode.UpArrow) && movementDirection != -1) {
            velocity = Vector3.up * speed; // Actualizar la velocidad hacia arriba
            movementDirection = 1; // Guardar la dirección del movimiento como hacia arriba
        } else if(Input.GetKey(KeyCode.DownArrow) && movementDirection != 1) {
            velocity = Vector3.down * speed; // Actualizar la velocidad hacia abajo
            movementDirection = -1; // Guardar la dirección del movimiento como hacia abajo
        } else {
            movementDirection = 0; // Si no se está pulsando ninguna tecla de movimiento, la dirección es cero (sin movimiento)
        }

        Vector3 newPosition = transform.position; // Obtener la posición actual de la barrera
        newPosition += velocity * Time.deltaTime; // Calcular la nueva posición basada en la velocidad y el tiempo transcurrido
        // Ajustamos la posición en el eje vertical entre el mínimo y el máximo permitidos
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition; // Aplicar la nueva posición a la barrera
    }
}
