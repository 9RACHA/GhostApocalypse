using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDigit : MonoBehaviour {

    // Array de sprites que representan los dígitos del marcador
    public Sprite[] digits;
    
    // Start is called before the first frame update
    void Start() {
        // Comprobamos si el array de dígitos está correctamente inicializado
        if(digits == null || digits.Length == 0) {
            Debug.Log("ScoreDigit: La variable digits no está correctamente inicializada");
        }     
    }

    // Método para establecer el dígito a mostrar
    public void SetDigit(int digit) {
        // Comprobamos si el valor del dígito está dentro del rango válido
        if(digit < 0 || digit >= digits.Length) {
            Debug.Log("ScoreDigit.SetDigit. Valor de digit fuera de rango: " + digit);
            return;
        }

        // Asignamos el sprite correspondiente al dígito
        GetComponent<SpriteRenderer>().sprite = digits[digit];
    }
}
