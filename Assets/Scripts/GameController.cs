using UnityEngine;

public class GameController : MonoBehaviour {

    public void GameOver() {
        for (int layer = 1; layer < PlayerPrefs.GetInt("Layer", 8) + 1; layer++) {
            for (int num = 1; num < 5; num++) {
                GameObject.Find($"{layer}_{num}").GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        GameObject.Find("MinoController").SetActive(false);
        Debug.Log("ゲームオーバー");
        GameObject.Find("GameOverPanel").SetActive(true);
    }
}
