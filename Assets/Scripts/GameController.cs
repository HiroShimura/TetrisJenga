using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject minoController;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject timeCoroutines;
    [SerializeField] GameObject countDown;

    TimeManager timeManager;
    Text countDownText;
    string[] players; // Optionでプレイヤー名を編集できるようにする予定

    void Awake() {
        timeManager = timer.GetComponent<TimeManager>();
        countDownText = countDown.GetComponent<Text>();
        countDownText.fontSize = 40;
        if (gameOverPanel.activeSelf)
            gameOverPanel.SetActive(false);
        if (pausePanel.activeSelf)
            pausePanel.SetActive(false);
        if (timeManager.enabled)
            timeManager.enabled = false;
        if (!countDown.activeSelf) {
            countDown.SetActive(true);
        }
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
        countDownText.text = "Player 1's turn...";
        yield return new WaitForSeconds(3);
        countDownText.fontSize = 65;
        countDownText.text = "5";
        yield return new WaitForSeconds(1);
        countDownText.text = "4";
        yield return new WaitForSeconds(1);
        countDownText.text = "3";
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        yield return new WaitForSeconds(1);
        countDownText.fontSize = 50;
        countDownText.text = "Start.";
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
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
