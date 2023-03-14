using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] vidas;
    public GameObject gameOverText;
    public ScorePoints scorePoints;
    public GameObject scoreSuperPower;

    public AudioClip ghostSpawnSound;
    public AudioClip ghostHitSound;

    //Para llevar la lista de fantasmas del juego y poderlos eliminar
    //al reiniciar el juego
    private List<GameObject> ghosts;

    private bool gameOver = false;
    private bool superPower = true;
    private int nextSuperPowerPoints = 1000;
    public bool GameOver { get { return gameOver; } }

    //Propiedad para el patrón singleton
    public static GameController instance;

    private int lifeCount = 4;
    private int score = 0;
    public GameObject ghostPrefab;

    public Transform[] spawnPoints;

    private AudioSource audioSource;
    private bool playHitSound = true;

    void Awake() {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null) {
            Debug.Log("GameController. No se ha encontrado el componente AudioSource");
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


        //Activamos la reprodución de sonido de ghostHit en este frame
        playHitSound = true;

        if(Input.GetKeyDown(KeyCode.Space) && superPower) {
            superPower = false;
            scoreSuperPower.SetActive(false);
            Superpower();
        }

        if(Random.Range(0f, 1f) < 0.001f) {
            SpawnGhost();
        } 
    }

    private void Superpower() {
        foreach(GameObject go in ghosts) {
            go.GetComponent<Ghost>().Die();
        }
    }

    private void InitGame() {
        
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

        score += points;
        Debug.Log("Score: " + score);
        scorePoints.Display(score);

        if(score >= nextSuperPowerPoints) {
            superPower = true;
            scoreSuperPower.SetActive(true);
            
            nextSuperPowerPoints += 2000;
        }
        if(playHitSound) {
            audioSource.PlayOneShot(ghostHitSound);
            //Desactivamos el sonido de ghostHit para el resto del frame
            playHitSound = false;
        }
    }

    public void BarreraSuperada() {
        lifeCount--;
        vidas[lifeCount].SetActive(false);
        if(lifeCount == 0) {
            SetGameOver();
        } else {
            Debug.Log("Vidas restantes " + lifeCount  );
        }

    }

    private void SetGameOver() {
        Debug.Log("GAME OVER");
        gameOver = true;
        gameOverText.SetActive(true);
    }

    private void SpawnGhost() {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        ghosts.Add(Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity));
        audioSource.PlayOneShot(ghostSpawnSound);
    }

    public void DestroyGhost(GameObject ghost) {
        ghosts.Remove(ghost);
        Destroy(ghost);
    } 

    private void DestroyAllGhosts() {
        foreach(GameObject go in ghosts) {
            Destroy(go);
        }
        ghosts.Clear();

    }
}
