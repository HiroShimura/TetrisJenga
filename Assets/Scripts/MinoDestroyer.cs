using UnityEngine;

public class MinoDestroyer : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (gameObject.transform.position.y < -50) {
            Destroy(gameObject);
        }
    }
}
