using UnityEngine;

public class GameOver : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("BottomMino")) {
            Debug.Log("ゲームオーバー");
        }
    }
}
