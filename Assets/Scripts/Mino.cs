using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Mino : MonoBehaviour {

    GameObject gameController;
    GameObject audioSource;
    AudioSource collisionSe;
    Color color;

    void Start() {
        gameController = GameObject.Find("GameController");
        audioSource = GameObject.Find("Audio Source");
        if (audioSource != null) {
            collisionSe = audioSource.GetComponent<AudioSource>();
        }
    }

    void OnMouseEnter() {
        if (gameController == null) {
            return;
        }
        color = GetComponent<Renderer>().material.color;
        if (Cursor.visible == true && Time.timeScale == 1) {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnMouseExit() {
        if (gameController == null) {
            return;
        }
        if (GetComponent<Renderer>().material.color == Color.white) {
            GetComponent<Renderer>().material.color = color;
        }
    }

    void Update() {
        if (transform.position.y < -10 && gameController != null) {
            GameController _gameController = gameController.GetComponent<GameController>();
            _gameController.GameOver();
        }
        else if (transform.position.y < -11) {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collisionSe != null && (collision.collider.CompareTag("StackedMino") || collision.collider.CompareTag("Untagged"))) {
            collisionSe.pitch = Random.Range(0.7f, 1.3f);
            collisionSe.Play();
        }
    }
}
