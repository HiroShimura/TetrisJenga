using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    [SerializeField] GameObject timeCoroutines;
    [SerializeField] GameObject gameOverPanel;
    string text;

    public float CountTime { get; set; }

    // Start is called before the first frame update
    void Start() {
        text = GetComponent<Text>().text;
        CountTime = PlayerPrefs.GetInt("Time");
    }

    // Update is called once per frame
    void Update() {
        if (CountTime <= 0) {
            if (timeCoroutines.activeSelf) {
                return;
            }
            timeCoroutines.SetActive(true);
            GetComponent<Text>().text = text + 0.ToString("F2");
        }
        else if (CountTime > 0) {
            if (GameObject.FindGameObjectWithTag("StackedMino") != null && Input.GetKeyDown(KeyCode.Space)) {
                timeCoroutines.SetActive(true);
            }
            if (gameOverPanel.activeSelf) {
                return;
            }
            else {
                CountTime -= Time.deltaTime;
                GetComponent<Text>().text = text + CountTime.ToString("F2");
            }
        }
    }
}
