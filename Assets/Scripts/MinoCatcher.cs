using UnityEngine;

public class MinoCatcher : MonoBehaviour {
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
        try {
            if (Input.GetMouseButtonDown(0)) {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RayCheck();
                PositionCheck();
            }
        }
        catch (System.NullReferenceException) {
            Debug.Log("カーソルをミノに合わせてください: Null");
        }
        if (beRay) {
            MovePosition();
        }
        else if (!beRay) {
            target = null;
        }
        if (Input.GetMouseButtonUp(0)) {
            if (target != null) {
                target.tag = "Mino";
            }
            beRay = false;
        }
    }

    void RayCheck() {
        if (Physics.Raycast(ray, out hit)) {
            target = hit.collider.gameObject;
            if (target.CompareTag("Mino") || target.CompareTag("BottomMino")) {
                beRay = true;
                target.tag = "BottomMino";
            }
            else {
                beRay = false;
            }
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
        if (target.transform.position.x < -6 || target.transform.position.x > 6 || target.transform.position.z < -6 || target.transform.position.z > 6) {
            Destroy(target);
            beRay = false;
        }
        target.GetComponent<Rigidbody>().MovePosition(new Vector3(moveTo.x + offset.x, targetPos.y, moveTo.z + offset.z));
    }
}
