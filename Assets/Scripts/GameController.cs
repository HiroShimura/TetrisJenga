using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject loser;
    [SerializeField] GameObject order;
    [SerializeField] GameObject countDown;
    [SerializeField] GameObject turn;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject minoController;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject timeCoroutines;
    List<string> players; // Optionでプレイヤー名を編集できるようにする予定

    TimeManager timeManager;
    Text countDownText;
    Text loserText;
    Text orderText;
    Text turnText;

    public int Turn { get; set; }
    public string[] Order { get; set; }

    void Awake() {
        // プレイヤーのリストを作成
        players = new List<string>();
        for (int i = 1; i < PlayerPrefs.GetInt("Player", 2) + 1; i++)
            players.Add("Player " + i);

        // 各キャッシュを作成
        timeManager = timer.GetComponent<TimeManager>();
        loserText = loser.GetComponent<Text>();
        orderText = order.GetComponent<Text>();
        turnText = turn.GetComponent<Text>();
        countDownText = countDown.GetComponent<Text>();
        countDownText.fontSize = 40;

        // 開始時に必要、不必要なオブジェクトがアクティブかどうか確認
        if (gameOverPanel.activeSelf)
            gameOverPanel.SetActive(false);
        if (pausePanel.activeSelf)
            pausePanel.SetActive(false);
        if (timeManager.enabled)
            timeManager.enabled = false;
        if (!countDown.activeSelf)
            countDown.SetActive(true);

        DecideOrder(); // 最初に作成したプレイヤーのリストから乱数で順番決め

        // ゲームスタート
        Time.timeScale = 1;
        StartCoroutine(GameStartCoroutine());
    }

    void Update() {
        turnText.text = Order[Turn] + "'s turn"; // UIの表示切替

        // Pauseのためのif文
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
        // UI表示
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

        // 必要、不必要なオブジェクトの切り替え
        countDown.SetActive(false);
        minoController.SetActive(true);
        timeManager.enabled = true;
    }

    void DecideOrder() {
        int randomNum; // ランダムにプレイヤーを決めるための変数
        int index = 0; // 新しい順番のインデックス

        Order = new string[players.Count()]; // シャッフルされた新しい順番の配列

        while (true) {
            randomNum = Random.Range(0, players.Count());
            Order[index] = players[randomNum];

            // 下のfor文の失敗からNullが怖かったので挿入
            if (Order[index] == null)
                continue;

            if (index == Order.Count() - 1)
                orderText.text += Order[index];
            else
                orderText.text += Order[index] + " -> ";
            index++;
            players.RemoveAt(randomNum);
            if (index == Order.Count())
                break;
        }

        // 下のfor文だとなぜかNullが(Listの要素数が3個 -> 1個、4個以上 -> 2個のNullがOrderに)入ってしまう。
        // なぜかはよくわからない...
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

        // 全てのミノのKinematicをtrueへ変更
        for (int layer = 1; layer < PlayerPrefs.GetInt("Layer", 8) + 1; layer++) {
            for (int num = 1; num < 5; num++) {
                var mino = GameObject.Find($"{layer}_{num}");
                if (mino == null)
                    continue;
                mino.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        loserText.text = $"Loser: {Order[Turn]}"; // 敗者の名前を表示

        minoController.SetActive(false); // ミノの操作を無効化
        timeCoroutines.SetActive(false); // 念のためタイムオーバーコルーティンが始まらないように無効化
        gameOverPanel.SetActive(true);
    }
}
