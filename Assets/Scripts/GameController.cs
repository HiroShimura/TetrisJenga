using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;

    void Awake() {
        if (gameOverPanel.activeSelf) gameOverPanel.SetActive(false);
    }

    public void GameOver() {
        for (int layer = 1; layer < PlayerPrefs.GetInt("Layer", 8) + 1; layer++) {
            for (int num = 1; num < 5; num++) {
                GameObject.Find($"{layer}_{num}").GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        GameObject.Find("MinoController").SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
