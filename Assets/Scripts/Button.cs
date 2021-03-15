using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public void StartButton() {
        SceneManager.LoadScene("GameScene");
    }

    public void OptionButton() {
        SceneManager.LoadScene("OptionScene");
    }

    public void TitleBackButton() {
        SceneManager.LoadScene("TitleScene");
    }

    public void ExitButton() {
        Application.Quit();
    }
}
