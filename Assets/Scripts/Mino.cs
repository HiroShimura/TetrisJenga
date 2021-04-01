using UnityEngine;

public class Mino : MonoBehaviour {

    GameObject gameController;
    Color color;

    void Start() {
        gameController = GameObject.Find("GameController");
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
            GameController _gameController = gameController.GetComponent<GameController>();
            _gameController.GameOver();
        }
    }
}
