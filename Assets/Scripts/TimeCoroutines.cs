using System.Collections;
using UnityEngine;

public class TimeCoroutines : MonoBehaviour {

    [SerializeField] GameObject minoController;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject Time;
    TimeManager timer;

    void Awake() {
        timer = Time.GetComponent<TimeManager>();
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
        Debug.Log("next");
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
        Debug.Log("After 3 sec, will be next player's turn.");
        yield return new WaitForSeconds(3);
        timer.CountTime = PlayerPrefs.GetInt("Time");
        minoController.SetActive(true);
        gameObject.SetActive(false);
    }
}
