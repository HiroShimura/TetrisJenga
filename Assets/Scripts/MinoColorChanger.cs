using UnityEngine;

public class MinoColorChanger : MonoBehaviour {

    Color color;

    void OnMouseEnter() {
        color = GetComponent<Renderer>().material.color;
        if ((GameObject.FindWithTag("SelectedMino") == null || CompareTag("SelectedMino") || CompareTag("StackedMino")) && Cursor.visible == true) {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnMouseExit() {
        if (GetComponent<Renderer>().material.color == Color.white) {
            GetComponent<Renderer>().material.color = color;
        }
    }
}
