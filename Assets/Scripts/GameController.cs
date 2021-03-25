using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject MinoController;

    void Awake() {
        if (gameOverPanel.activeSelf) gameOverPanel.SetActive(false);
        if (pausePanel.activeSelf) pausePanel.SetActive(false);
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

    void TimeOver() {
        GameObject vanishedMino;
        while (true) {
            int high = PlayerPrefs.GetInt("Layer", 8) + 1;
            int layer = Random.Range(1, high);
            int num = Random.Range(1, 5);
            vanishedMino = GameObject.Find($"{layer}_{num}");
            if (vanishedMino == null) continue;
            else break;
        }
        Destroy(vanishedMino);
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
