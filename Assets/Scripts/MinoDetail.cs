using UnityEngine;

public class MinoDetail : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnMouseEnter() {
        Debug.Log("マウスオーバー");
    }
    private void OnMouseExit() {
        Debug.Log("カーソルが外れました");
    }
}
