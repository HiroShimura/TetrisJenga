using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        var button = GetComponent<Button>();
        button.onClick.AddListener(() => SceneManager.LoadScene("GameScene"));
    }

    // Update is called once per frame
    void Update() {

    }
}
