using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {
    
    // Tiempo de vida y velocidad de movimiento de los puntos
    float timeToLive = 1.2f;
    float speed = 2.5f;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start() {
        // Configuración inicial de los puntos
        velocity = Vector3.up * speed;        
    }

    // Update is called once per frame
    void Update() {
        // Movimiento de los puntos hacia arriba
        transform.position += velocity * Time.deltaTime;

        // Obtención del componente SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color spriteColor = spriteRenderer.color;

        // Reducción del canal alfa de spriteColor en función del deltaTime de este frame
        spriteColor.a -= Time.deltaTime / timeToLive;

        // Asignación del nuevo valor de color si no ha alcanzado la invisibilidad
        if(spriteColor.a > 0) {
            spriteRenderer.color = spriteColor;
        } else {
            Destroy(gameObject);
        }
    }
}
