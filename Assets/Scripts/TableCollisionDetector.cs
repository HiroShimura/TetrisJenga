using UnityEngine;
using UnityEngine.Events;

public class TableCollisionDetector : MonoBehaviour {

    [SerializeField] UnityEvent onCollisionEnter = new UnityEvent();

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("BottomMino")) {
            onCollisionEnter.Invoke();
        }
    }
}
