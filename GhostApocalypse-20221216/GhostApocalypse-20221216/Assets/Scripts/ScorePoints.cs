using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour {
    public ScoreDigit[] scoreDigits;
    // Start is called before the first frame update
    void Start() {
        if(scoreDigits == null || scoreDigits.Length == 0) {
            Debug.Log("ScorePoints: La variable scoreDigits no está correctamente inicializada");
        }
        
    }

    public void Display(int value) {
        Debug.Log("ScorePoints.Display value: " + value);
        for(int i=0; i<scoreDigits.Length; i++) {
            scoreDigits[i].SetDigit(value % 10);
            value = value / 10;
        }

    }
}
