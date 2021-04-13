using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Mino : MonoBehaviour {

    AudioSource collisionSe;
    GameObject gameController;
    Color color;

    void Start() {
        gameController = GameObject.Find("GameController");
        // collisionSe = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    void OnMouseEnter() {
        color = GetComponent<Renderer>().material.color;
        if (Cursor.visible == true && Time.timeScale == 1) {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnMouseExit() {
        if (GetComponent<Renderer>().material.color == Color.white) {
            GetComponent<Renderer>().material.color = color;
        }
    }

    void Update() {
        if (transform.position.y < -10) {
            //GameController _gameController = gameController.GetComponent<GameController>();
            //_gameController.GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("StackedMino") || collision.collider.CompareTag("Untagged")) {
            collisionSe.pitch = Random.Range(0.7f, 1.3f);
            collisionSe.Play();
        }
    }
}
