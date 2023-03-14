using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDigit : MonoBehaviour {

    public Sprite[] digits;
    
    // Start is called before the first frame update
    void Start() {
        if(digits == null || digits.Length == 0) {
            Debug.Log("ScoreDigit: La variable digits no está correctamente inicializada");
        }     
    }

    public void SetDigit(int digit) {
        if(digit < 0 || digit >= digits.Length) {
            Debug.Log("ScoreDigit.SetDigit. Valor de digit fuera de rango: " + digit);
            return;
        }

        GetComponent<SpriteRenderer>().sprite = digits[digit];
    }
}
