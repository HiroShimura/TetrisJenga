using System.Collections;
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

    void OnDisable() {
        Debug.Log("コルーチンが無効になりました");
    }

    IEnumerator ToNextTurnCoroutin() {
        yield return new WaitForSeconds(5);
        _gameController.Turn++;
        countDownText.text = "Next";
        countDownUI.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownText.fontSize = 40;
        countDownText.text = $"{_gameController.Order[_gameController.Turn]}'s turn...";
        yield return new WaitForSeconds(1);
        countDownText.fontSize = 50;
        countDownText.text = "Start";
        yield return new WaitForSeconds(1);
        countDownUI.SetActive(false);
        timer.CountTime = PlayerPrefs.GetInt("Time");
        gameObject.SetActive(false);
    }

    IEnumerator TimeOverCroutine() {
        Debug.Log("Time Over");
        if (gameOverPanel.activeSelf) {
            StopAllCoroutines();
        }
        yield return new WaitForSeconds(2);
        Debug.Log("Randomly selected Minos will be erased, and selected Mino drop.");
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
        GameObject.FindWithTag("StackedMino").GetComponent<Rigidbody>().isKinematic = false;
        Debug.Log("After 5 sec, will be next player's turn.");
        yield return new WaitForSeconds(3);
        timer.CountTime = PlayerPrefs.GetInt("Time");
        minoController.SetActive(true);
        gameObject.SetActive(false);
    }
}
