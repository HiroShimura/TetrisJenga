using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TimeCoroutines : MonoBehaviour {

    [SerializeField] GameObject gameController;
    [SerializeField] GameObject minoController;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject countDownUI;
    [SerializeField] GameObject Time;
    GameController _gameController;
    TimeManager timer;
    Text countDownText;

    void Awake() {
        timer = Time.GetComponent<TimeManager>();
        _gameController = gameController.GetComponent<GameController>();
        countDownText = countDownUI.GetComponent<Text>();

    }

    void OnEnable() {
        if (timer.CountTime > 0) {
            StartCoroutine(ToNextTurnCoroutin());
        }
        else if (timer.CountTime <= 0) {
            minoController.SetActive(false);
            StartCoroutine(TimeOverCroutine());
        }
    }

    IEnumerator ToNextTurnCoroutin() {
        timer.Sta = null;
        timer.NotNull = false;
        yield return new WaitForSeconds(5);
        minoController.SetActive(false);
        countDownText.fontSize = 50;
        countDownText.text = "Next";
        countDownUI.SetActive(true);
        yield return new WaitForSeconds(1);
        _gameController.Turn++;
        if (_gameController.Turn >= _gameController.Order.Count()) _gameController.Turn = 0;
        countDownText.fontSize = 40;
        countDownText.text = $"{_gameController.Order[_gameController.Turn]}'s turn...";
        yield return new WaitForSeconds(2);
        countDownText.fontSize = 50;
        countDownText.text = "Start";
        minoController.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownUI.SetActive(false);
        timer.CountTime = PlayerPrefs.GetInt("Time");
        gameObject.SetActive(false);
    }

    IEnumerator TimeOverCroutine() {
        countDownUI.SetActive(true);
        countDownText.text = "Time Over";
        if (gameOverPanel.activeSelf) StopAllCoroutines();
        yield return new WaitForSeconds(2);
        countDownText.fontSize = 30;
        countDownText.text = "Randomly selected Minos will be erased, and selected Mino drop.";
        yield return new WaitForSeconds(3);
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
        Destroy(vanishedMino);
        var a = GameObject.FindWithTag("StackedMino");
        var b = GameObject.FindWithTag("SelectedMino");
        if (a) {
            a.GetComponent<Rigidbody>().isKinematic = false;
            a.tag = "Mino";
        }
        else if (b) {
            b.GetComponent<Rigidbody>().isKinematic = false;
            b.tag = "Mino";
        }

        countDownText.fontSize = 40;
        countDownText.text = "After 5 sec, will be next player's turn.";
        yield return new WaitForSeconds(2);
        countDownUI.SetActive(false);
        StartCoroutine(ToNextTurnCoroutin());
    }
}
