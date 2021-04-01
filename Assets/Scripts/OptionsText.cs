using UnityEngine;
using UnityEngine.UI;

public class OptionsText : MonoBehaviour {

    GameObject slider;
    string text;

    // Start is called before the first frame update
    void Start() {
        slider = GameObject.Find($"{name}Slider");
        text = GetComponent<Text>().text;
        slider.GetComponent<Slider>().value = PlayerPrefs.GetInt(name);
        if (name == "Time") GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value} sec";
        else GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value}";
    }

    public void ValueChanged() {
        if (name == "Time") {
            GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value} sec";
            PlayerPrefs.SetInt("Time", (int)slider.GetComponent<Slider>().value);
        }
        if (name == "Layer") {
            GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value}";
            PlayerPrefs.SetInt("Layer", (int)slider.GetComponent<Slider>().value);
        }
        if (name == "Player") {
            GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value}";
            PlayerPrefs.SetInt("Player", (int)slider.GetComponent<Slider>().value);
        }
    }
}
