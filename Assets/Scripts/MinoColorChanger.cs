using UnityEngine;

public class MinoColorChanger : MonoBehaviour {

    Color color;

    void OnMouseEnter() {
        color = GetComponent<Renderer>().material.color;
        if (Cursor.visible == true) {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnMouseExit() {
        if (GetComponent<Renderer>().material.color == Color.white) {
            GetComponent<Renderer>().material.color = color;
        }
    }
}
