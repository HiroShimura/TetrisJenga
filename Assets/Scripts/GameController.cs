using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject minoController;
    [SerializeField] GameObject timeCoroutines;

    void Awake() {
        if (gameOverPanel.activeSelf)
            gameOverPanel.SetActive(false);
        if (pausePanel.activeSelf)
            pausePanel.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pausePanel.activeSelf) {
                minoController.SetActive(false);
                pausePanel.SetActive(true);
            }
            else {
                pausePanel.SetActive(false);
                minoController.SetActive(true);
            }
        }
    }

    public void GameOver() {
        for (int layer = 1; layer < PlayerPrefs.GetInt("Layer", 8) + 1; layer++) {
            for (int num = 1; num < 5; num++) {
                var mino = GameObject.Find($"{layer}_{num}");
                if (mino == null)
                    continue;
                mino.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        minoController.SetActive(false);
        timeCoroutines.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
