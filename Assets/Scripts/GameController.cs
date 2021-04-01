using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject loserText;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject minoController;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject timeCoroutines;
    [SerializeField] GameObject countDown;
    [SerializeField] List<string> players; // Optionでプレイヤー名を編集できるようにする予定

    TimeManager timeManager;
    Text countDownText;
    Text _loserText;

    public int Turn { get; set; }
    public string[] Order { get; set; }

    void Awake() {
        timeManager = timer.GetComponent<TimeManager>();
        countDownText = countDown.GetComponent<Text>();
        _loserText = loserText.GetComponent<Text>();
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
        int index;
        int num = 0;
        Order = new string[players.Count()];
        while (true) {
            index = Random.Range(0, players.Count());
            Order[num] = players[index];
            if (Order[num] == null) continue;
            num++;
            players.RemoveAt(index);
            if (num == Order.Count()) break;
        }

        // 下のfor文だとなぜかNullが(Listの要素数が3個 -> 1個、4個以上 -> 2個のNullがOrderに)入ってしまいました。
        // なぜかはよくわかりません()
        /*
        for (int i = 0; i < players.Count(); i++) {
            index = Random.Range(0, players.Count());
            Order[i] = players[index];
            players.RemoveAt(index);
        }
        */
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
        _loserText.text = $"Loser: {Order[Turn]}";
        minoController.SetActive(false);
        timeCoroutines.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
