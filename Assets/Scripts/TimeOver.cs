using UnityEngine;

public class TimeOver : MonoBehaviour {

    void Awake() {
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.V)) {
            gameObject.SetActive(true);
        }
    }

    void OnEnable() {
        Debug.Log("有効になりました。");
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
        gameObject.SetActive(false);
    }
}
