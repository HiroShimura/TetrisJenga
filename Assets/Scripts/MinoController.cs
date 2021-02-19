using UnityEngine;

public class MinoController : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    bool beRay = false;
    GameObject target;
    Vector3 targetPos;
    Vector3 offset;

    // Start is called before the first frame update
    void Start() {

    }


    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RayCheck();
            PositionCheck();
        }
        if (beRay) {
            MovePosition();
        }
        if (Input.GetMouseButtonUp(0)) {
            beRay = false;
        }
    }

    void RayCheck() {
        if (Physics.Raycast(ray, out hit)) {
            target = hit.collider.gameObject;
            beRay = true;
        }
        /*
        if (Physics.Raycast(ray, out hit) && hit.collider == gameObject.GetComponent<Collider>()) {
            beRay = true;
        }
        */
        else {
            beRay = false;
        }
    }

    void PositionCheck() {
        Vector3 mousePos = Input.mousePosition;
        float depth = Camera.main.transform.InverseTransformPoint(hit.point).z;
        mousePos.z = depth;
        targetPos = target.transform.position;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        offset = targetPos - worldMousePos;
    }

    void MovePosition() {
        Vector3 mousePos = Input.mousePosition;
        float depth = Camera.main.transform.InverseTransformPoint(hit.point).z;
        mousePos.z = depth;
        Vector3 moveTo = Camera.main.ScreenToWorldPoint(mousePos);
        target.transform.position = new Vector3(moveTo.x + offset.x, targetPos.y, moveTo.z + offset.z);
    }
}
