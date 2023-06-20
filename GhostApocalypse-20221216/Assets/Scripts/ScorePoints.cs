using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour {

    // Array de ScoreDigit que representan los dígitos del marcador de puntuación
    public ScoreDigit[] scoreDigits;
    
    // Start is called before the first frame update
    void Start() {
        // Comprobamos si el array de ScoreDigit está correctamente inicializado
        if(scoreDigits == null || scoreDigits.Length == 0) {
            Debug.Log("ScorePoints: La variable scoreDigits no está correctamente inicializada");
        }
    }

    // Método para mostrar la puntuación
    public void Display(int value) {
        Debug.Log("ScorePoints.Display value: " + value);

        // Iteramos sobre cada ScoreDigit en el array
        for(int i = 0; i < scoreDigits.Length; i++) {
            // Establecemos el dígito correspondiente al valor actual
            scoreDigits[i].SetDigit(value % 10);
            // Dividimos el valor por 10 para obtener el siguiente dígito
            value = value / 10;
        }
    }
}

