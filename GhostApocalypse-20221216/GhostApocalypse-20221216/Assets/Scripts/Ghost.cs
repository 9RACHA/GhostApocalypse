using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    public GameObject points100Prefab;
    public GameObject points150Prefab;

    private bool notified = false;
    private float speed = 6f;
    private Vector3 velocity;
    private int points;
    // Start is called before the first frame update
    void Start() {
        velocity = Vector3.right * speed;
        points = 100;
        //En uno de cada 10 casos, el fantasma decide moverse en diagonal
        if(Random.Range(0f, 1f) <= 0.1f) {
            float randomY = Random.Range(-5f, 5f);
            Vector3 targetPoint = new Vector3(8.5f, randomY, 0);
            //Calculamos el vector de dirección que nos lleva
            //de la posición actual a la posición aleatoria elegida
            Vector3 velocityDirection = targetPoint - transform.position;
            //Normalizamos el vector de direccion
            velocityDirection.Normalize();
            //Calculamos la velocity, a partir de la dirección
            velocity = velocityDirection * speed;
            //Los fantasmas que se mueven en diagonal puntuan más
            points = 150;
       }
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(GameController.instance.GameOver) {
            return;
        }

        Vector3 movement = velocity * Time.fixedDeltaTime;
        transform.position = transform.position + movement;

        //Si el fantasma pasa de la coordenada 10, se resta una vida
        if(transform.position.x > 10f && ! notified) {
            //Restamos una vida
            GameController.instance.BarreraSuperada();
            notified = true;
        }

        //Al pasar de la coordenada 20, destruimos el fantasma
        if(transform.position.x > 20f) {
            DestroyGhost();
        }     
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Fantasma colisionó");

        if(other.gameObject.CompareTag("Player")) {
            Die();
        }

    }

    public void Die() {

        //Si el fantasma ya ha pasado de la barrera no se muere
        //Esto es necesario para cuando el GameController usa el superpoder
        if(notified) {
            return;
        }

        velocity = Vector3.zero;
        GetComponent<Animator>().SetBool("exploding", true);
        GameController.instance.AddScore(points);
        //Instancio el prefab que informa de los puntos generados
        if(points == 100) {
            Instantiate(points100Prefab, transform.position + Vector3.up, Quaternion.identity);
        } else {
             Instantiate(points150Prefab, transform.position + Vector3.up, Quaternion.identity);
        }
    }

    void DestroyGhost() {
        GameController.instance.DestroyGhost(gameObject);
    }
}
