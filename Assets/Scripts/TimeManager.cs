using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    [SerializeField] GameObject timeCoroutines;
    [SerializeField] GameObject gameOverPanel;
    string text;

    public float CountTime { get; set; }
    public GameObject Sta { get; set; }
    public bool NotNull { get; set; } = false;

    // Start is called before the first frame update
    void Start() {
        text = GetComponent<Text>().text;
        CountTime = PlayerPrefs.GetInt("Time");
    }

    // Update is called once per frame
    void Update() {
        if (timeCoroutines.activeSelf)
            return;
        if (CountTime <= 0) {
            timeCoroutines.SetActive(true);
            GetComponent<Text>().text = text + 0.ToString("F2");
        }
        else if (CountTime > 0) {
            Sta = GameObject.FindWithTag("StackedMino");
            if (NotNull == true && Input.GetKeyDown(KeyCode.Space)) timeCoroutines.SetActive(true);
            else if (Sta != null) NotNull = true;
            CountTime -= Time.deltaTime;
            GetComponent<Text>().text = text + CountTime.ToString("F2");
        }
    }
}
