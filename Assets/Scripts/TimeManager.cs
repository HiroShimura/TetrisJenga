using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    [SerializeField] GameObject timeCoroutines;
    [SerializeField] GameObject gameOverPanel;
    string text;

    public float CountTime { get; set; }
    public GameObject StackedMino { get; set; }
    public bool NotNull { get; set; } = false;

    void Start() {
        text = GetComponent<Text>().text; // "Time: "
        CountTime = PlayerPrefs.GetInt("Time", 20); // オプションで設定した時間をセット
    }

    void Update() {
        // コルーティン中はvoidを返させる
        if (timeCoroutines.activeSelf)
            return;

        // 時間切れ
        if (CountTime <= 0) {
            timeCoroutines.SetActive(true); // 時間切れのコルーティンを開始するため
            GetComponent<Text>().text = text + 0.ToString("F2"); // 0.00を表示
        }

        // 操作中
        else if (CountTime > 0) {
            StackedMino = GameObject.FindWithTag("StackedMino"); // 空中にあるミノを探す

            // 空中にミノが存在し、Spaceが押された場合に次のプレイヤーへ遷移するコルーティンを開始するため
            if (NotNull == true && Input.GetKeyDown(KeyCode.Space))
                timeCoroutines.SetActive(true);

            // 空中にミノがあることを確認
            else if (StackedMino != null)
                NotNull = true;

            // 残り時間の表示
            CountTime -= Time.deltaTime;
            GetComponent<Text>().text = text + CountTime.ToString("F2");
        }
    }
}
