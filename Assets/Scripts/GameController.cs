using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject minoController;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject timeCoroutines;
    [SerializeField] GameObject countDown;
    [SerializeField] List<string> players; // Optionでプレイヤー名を編集できるようにする予定

    TimeManager timeManager;
    Text countDownText;
    private int turn = 0;

    public int Turn {
        get => turn;
        set {
            if (turn > players.Count())
                turn = 0;
        }
    }
    public string[] Order { get; set; }

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
        if (!countDown.activeSelf)
            countDown.SetActive(true);
        DecideOrder();
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
        countDownText.text = $"{Order[Turn]}'s turn...";
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
        countDownText.text = "Start";
        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        minoController.SetActive(true);
        timeManager.enabled = true;
    }

    void DecideOrder() {
        Order = new string[players.Count()];
        for (int i = 0; i < players.Count(); i++) {
            int index = Random.Range(0, players.Count());
            Order[i] = players[index];
            players.RemoveAt(index);
        }
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
