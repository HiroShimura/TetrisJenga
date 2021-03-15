using UnityEngine;

public class MinoDetail : MonoBehaviour {

    Color color;

    private void OnMouseEnter() {
        color = GetComponent<Renderer>().material.color;
        if ((GameObject.FindWithTag("SelectedMino") == null || CompareTag("StackedMino")) && Cursor.visible == true) {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void OnMouseExit() {
        if (GetComponent<Renderer>().material.color == Color.white) {
            GetComponent<Renderer>().material.color = color;
        }
    }
}
