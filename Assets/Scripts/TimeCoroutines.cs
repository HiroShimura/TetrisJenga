using System.Collections;
using UnityEngine;

public class TimeCoroutines : MonoBehaviour {

    [SerializeField] GameObject minoController;
    [SerializeField] GameObject Time;
    TimeManager timer;

    void Awake() {
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
        timer = Time.GetComponent<TimeManager>();
    }

    void OnEnable() {
        if (timer.CountTime > 0) {
            Debug.Log("next");
            gameObject.SetActive(false);
        }
        else if (timer.CountTime <= 0) {
            minoController.SetActive(false);
            StartCoroutine(TimeOverCroutine());
        }
    }

    void OnDisable() {
        StopAllCoroutines();
    }


    IEnumerator TimeOverCroutine() {
        Debug.Log("Time Over");
        yield return new WaitForSeconds(2);
        Debug.Log("Randomly selected Minos will be erased.");
        yield return new WaitForSeconds(3);
        GameObject vanishedMino;
        while (true) {
            int high = PlayerPrefs.GetInt("Layer", 8) + 1;
            int layer = Random.Range(1, high);
            int num = Random.Range(1, 5);
            vanishedMino = GameObject.Find($"{layer}_{num}");
            if (vanishedMino == null) continue;
            else break;
        }
        Destroy(vanishedMino);
        Debug.Log("After 3 sec, will be next player's turn.");
        yield return new WaitForSeconds(3);
        timer.CountTime = PlayerPrefs.GetInt("Time");
        minoController.SetActive(true);
        gameObject.SetActive(false);
    }
}
