using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Referencias a los objetos del juego
    public GameObject[] vidas;
    public GameObject gameOverText;
    public ScorePoints scorePoints;
    public GameObject scoreSuperPower;

    // Sonidos del juego
    public AudioClip ghostSpawnSound;
    public AudioClip ghostHitSound;

    // Lista de fantasmas en el juego y banderas de estado
    private List<GameObject> ghosts;
    private bool gameOver = false;
    private bool superPower = true;
    private int nextSuperPowerPoints = 1000;
    public bool GameOver { get { return gameOver; } }

    // Instancia del GameManager para el patrón singleton
    public static GameManager instance;

    private int lifeCount = 4;
    private int score = 0;
    public GameObject ghostPrefab; //Referecia al prefab que se creara

    public Transform[] spawnPoints; //Posicion de spawn de los fantasmas

    private AudioSource audioSource; //Componente que añadir para que suene 
    private bool playHitSound = true;

    void Awake() {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null) {
            Debug.Log("GameManager. No se ha encontrado el componente AudioSource");
        }
    }

    void Start() {
        scorePoints.Display(0);
        ghosts = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        if(GameOver) {
            if(Input.GetKeyDown(KeyCode.F1)) {
                InitGame();
            }
            return;
        }

        // Activamos la reproducción de sonido de ghostHit en este frame
        playHitSound = true;

        // Control de la habilidad especial (Superpower)
        if(Input.GetKeyDown(KeyCode.Space) && superPower) {
            superPower = false;
            scoreSuperPower.SetActive(false);
            Superpower();
        }

        // Generación aleatoria de fantasmas
        if(Random.Range(0f, 1f) < 0.001f) {
            SpawnGhost();
        } 
    }

    private void Superpower() {
        foreach(GameObject go in ghosts) {
            go.GetComponent<Fantasma>().Die();
        }
    }

    private void InitGame() {
        // Inicialización del juego
        lifeCount = 4;
        score = 0;
        scorePoints.Display(0);
        gameOverText.SetActive(false);

        superPower = true;
        scoreSuperPower.SetActive(true);
        
        DestroyAllGhosts();

        foreach(GameObject v in vidas) {
            v.SetActive(true);
        }

        gameOver = false;  
    }

    public void AddScore(int points) {
        // Añadir puntos al marcador
        score += points;
        Debug.Log("Score: " + score);
        scorePoints.Display(score);

        // Verificar si se ha alcanzado el siguiente nivel de Superpower
        if(score >= nextSuperPowerPoints) {
            superPower = true;
            scoreSuperPower.SetActive(true);
            nextSuperPowerPoints += 2000;
        }

        // Reproducir sonido de golpe a un fantasma
        if(playHitSound) {
            audioSource.PlayOneShot(ghostHitSound);
        // Desactivamos el sonido de golpe para el resto del frame
        playHitSound = false;
        }
        }public void BarreraSuperada() {
    // Manejo de la barrera cuando es superada
    lifeCount--;
    vidas[lifeCount].SetActive(false);
    if(lifeCount == 0) {
        SetGameOver();
    } else {
        Debug.Log("Vidas restantes: " + lifeCount);
    }
}

private void SetGameOver() {
    // Establecer el estado de Game Over
    Debug.Log("GAME OVER");
    gameOver = true;
    gameOverText.SetActive(true);
}

private void SpawnGhost() {
    // Generar un fantasma en un punto de generación aleatorio
    Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

    ghosts.Add(Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity));
    audioSource.PlayOneShot(ghostSpawnSound);
}

public void DestroyGhost(GameObject ghost) {
    // Eliminar un fantasma de la lista y destruirlo
    ghosts.Remove(ghost);
    Destroy(ghost);
} 

private void DestroyAllGhosts() {
    // Destruir todos los fantasmas en la lista
    foreach(GameObject go in ghosts) {
        Destroy(go);
    }
    ghosts.Clear();
}
}

