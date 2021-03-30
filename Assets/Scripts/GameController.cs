using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject minoController;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject timeCoroutines;

    TimeManager timeManager;
    string[] players; // Optionでプレイヤー名を編集できるようにする予定

    void Awake() {
        if (gameOverPanel.activeSelf)
            gameOverPanel.SetActive(false);
        if (pausePanel.activeSelf)
            pausePanel.SetActive(false);
        timeManager = timer.GetComponent<TimeManager>();
        if (timeManager.enabled)
            timeManager.enabled = false;
        Time.timeScale = 1;
        StartCoroutine(GameStartCoroutine());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pausePanel.activeSelf) {
                minoController.SetActive(false);
                pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else {
                pausePanel.SetActive(false);
                minoController.SetActive(true);
                Time.timeScale = 1;
            }
        }
    }

    IEnumerator GameStartCoroutine() {
        Debug.Log("Player 1's turn...");
        yield return new WaitForSeconds(1);
        Debug.Log("5");
        yield return new WaitForSeconds(1);
        Debug.Log("4");
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        Debug.Log("Start.");
        minoController.SetActive(true);
        timeManager.enabled = true;
    }

    public void GameOver() {
        Time.timeScale = 0;
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
