using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject MinoController;

    void Awake() {
        if (gameOverPanel.activeSelf) gameOverPanel.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pausePanel.activeSelf) {
                MinoController.SetActive(false);
                pausePanel.SetActive(true);
            }
            else {
                pausePanel.SetActive(false);
                MinoController.SetActive(true);
            }
        }
    }

    public void GameOver() {
        for (int layer = 1; layer < PlayerPrefs.GetInt("Layer", 8) + 1; layer++) {
            for (int num = 1; num < 5; num++) {
                GameObject.Find($"{layer}_{num}").GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        MinoController.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
