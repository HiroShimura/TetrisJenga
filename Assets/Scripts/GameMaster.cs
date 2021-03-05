using UnityEngine;

public class GameMaster : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        GameObject stackedMino = GameObject.FindWithTag("StackedMino");
        if (stackedMino != null) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                stackedMino.GetComponent<Rigidbody>().isKinematic = false;
                stackedMino.tag = "Mino";
            }
            else if (Input.GetKey(KeyCode.W)) {
                stackedMino.transform.Rotate(-0.5f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A)) {
                stackedMino.transform.Rotate(0, -0.5f, 0);
            }
            else if (Input.GetKey(KeyCode.S)) {
                stackedMino.transform.Rotate(0.5f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D)) {
                stackedMino.transform.Rotate(0, 0.5f, 0);
            }
        }
    }
}
