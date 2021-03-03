using UnityEngine;

public class MinoDetail : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnMouseEnter() {
        if (!(Input.GetMouseButton(1) || Input.GetMouseButton(2))) {
            Debug.Log("マウスオーバー");
        }
    }
    private void OnMouseExit() {
        if (!(Input.GetMouseButton(1) || Input.GetMouseButton(2))) {
            Debug.Log("カーソルが外れました");
        }
    }
}
