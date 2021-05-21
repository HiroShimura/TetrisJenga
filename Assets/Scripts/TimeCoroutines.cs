using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TimeCoroutines : MonoBehaviour {

    [SerializeField] GameObject gameController;
    [SerializeField] GameObject minoController;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject countDownUI;
    [SerializeField] GameObject Timer;
    GameController _gameController;
    TimeManager timer;
    Text countDownText;

    Vector3 defaultCameraPos;
    Vector3 nextCameraPos;
    int turnNum = 0;

    void Awake() {
        defaultCameraPos = Camera.main.transform.position;
        // 各キャッシュを取得
        timer = Timer.GetComponent<TimeManager>();
        _gameController = gameController.GetComponent<GameController>();
        countDownText = countDownUI.GetComponent<Text>();
    }

    void OnEnable() {
        if (timer.CountTime > 0)
            StartCoroutine(ToNextTurnCoroutin()); // 次のプレイヤーへ遷移するためのコルーティン
        else if (timer.CountTime <= 0) {
            minoController.SetActive(false);
            StartCoroutine(TimeOverCroutine()); // 時間切れのコルーティン
        }
    }

    IEnumerator ToNextTurnCoroutin() {
        // timer.StackedMino = null; 2021/04/04 コメントアウトしてても動作してるが、念のため保管
        timer.NotNull = false; // 空中にミノはない(はずな)ので切り替え
        yield return new WaitForSeconds(5);
        minoController.SetActive(false); // 操作無効化
        turnNum++;
        nextCameraPos = new Vector3(defaultCameraPos.x + turnNum, defaultCameraPos.y + turnNum, 0);
        /*
        while (true) {
            if (Camera.main.transform.position == nextCameraPos) {
                break;
            }
            Camera.main.transform.Translate(nextCameraPos * Time.deltaTime);
        }
        */

        // UI表示
        countDownText.fontSize = 50;
        countDownText.text = "Next";
        countDownUI.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownText.fontSize = 40;
        if (_gameController.Turn + 1 == _gameController.Order.Count())
            countDownText.text = $"{_gameController.Order[0]}'s turn...";
        else
            countDownText.text = $"{_gameController.Order[_gameController.Turn + 1]}'s turn...";

        // StackedMinoのタグを切り替えてからNullを代入
        if (timer.StackedMino != null) {
            timer.StackedMino.tag = "Mino";
            timer.StackedMino = null;
        }

        yield return new WaitForSeconds(2);
        countDownText.fontSize = 50;
        countDownText.text = "Start";

        // ここからプレイヤー切り替え
        _gameController.Turn++;
        if (_gameController.Turn >= _gameController.Order.Count())
            _gameController.Turn = 0;
        minoController.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownUI.SetActive(false);
        timer.CountTime = PlayerPrefs.GetInt("Time");
        gameObject.SetActive(false);
    }

    IEnumerator TimeOverCroutine() {
        // UI表示開始
        countDownUI.SetActive(true);
        countDownText.text = "Time Over";

        // 時間切れ後にミノが落ちてゲームオーバーになった場合にコルーティンを止める
        if (gameOverPanel.activeSelf)
            StopAllCoroutines();

        yield return new WaitForSeconds(2);
        countDownText.fontSize = 30;
        countDownText.text = "Randomly selected Minos will be erased, and selected Mino drop.";
        yield return new WaitForSeconds(3);

        // 時間切れペナルティーで消えるミノを選定
        GameObject vanishedMino;
        while (true) {
            int high = PlayerPrefs.GetInt("Layer", 8) + 1;
            int layer = Random.Range(1, high);
            int num = Random.Range(1, 5);
            vanishedMino = GameObject.Find($"{layer}_{num}");
            if (vanishedMino == null)
                continue;
            else
                break;
        }
        Destroy(vanishedMino); // 上で選定されたミノの削除

        // 空中、または選択されたミノがあれば状態をリセット
        var stackedMino = GameObject.FindWithTag("StackedMino");
        var selectedMino = GameObject.FindWithTag("SelectedMino");
        if (stackedMino) {
            stackedMino.GetComponent<Rigidbody>().isKinematic = false;
            stackedMino.tag = "Mino";
        }
        else if (selectedMino) {
            selectedMino.GetComponent<Rigidbody>().isKinematic = false;
            selectedMino.tag = "Mino";
        }

        countDownText.fontSize = 40;
        countDownText.text = "After 5 sec, will be next player's turn.";
        yield return new WaitForSeconds(2);
        countDownUI.SetActive(false);
        StartCoroutine(ToNextTurnCoroutin()); // 次のプレイヤーへ遷移
    }
}
