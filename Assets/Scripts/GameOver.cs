using UnityEngine;

public class GameOver : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Mino")) {
            Debug.Log("ゲームオーバー");
        }
    }
}
