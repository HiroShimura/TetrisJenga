using UnityEngine;
using UnityEngine.UI;

/*
class Options {
    static Options option;
    public float Layers { get; set; } = GameObject.Find($"LayerSlider").GetComponent<Slider>().value;
    public float Time { get; set; } = GameObject.Find($"TimeSlider").GetComponent<Slider>().value;
    Options() {
    }
    public static Options Option() {
        if (option == null) {
            option = new Options();
        }
        return option;
    }
}
*/
public class OptionsText : MonoBehaviour {

    GameObject slider;
    string text;

    // Start is called before the first frame update
    void Start() {
        // float layers = Options.Option().Layers;
        // float time = Options.Option().Time;
        slider = GameObject.Find($"{name}Slider");
        text = GetComponent<Text>().text;
        slider.GetComponent<Slider>().value = PlayerPrefs.GetInt(name);
        if (name == "Time") {
            GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value}秒";
        }
        else {
            GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value}";
        }
    }

    public void ValueChanged() {
        if (name == "Time") {
            GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value}秒";
            PlayerPrefs.SetInt("Time", (int)slider.GetComponent<Slider>().value);
        }
        else {
            GetComponent<Text>().text = $"{text}{slider.GetComponent<Slider>().value}";
            PlayerPrefs.SetInt("Layer", (int)slider.GetComponent<Slider>().value);
        }
    }
}
