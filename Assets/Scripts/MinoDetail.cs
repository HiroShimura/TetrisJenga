using UnityEngine;

public class MinoDetail : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    Color color;
    private void OnMouseEnter() {
        if (!(Input.GetMouseButton(1) || Input.GetMouseButton(2))) {
            Debug.Log("マウスオーバー");
            color = gameObject.GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    private void OnMouseExit() {
        if (!(Input.GetMouseButton(1) || Input.GetMouseButton(2))) {
            Debug.Log("カーソルが外れました");
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
