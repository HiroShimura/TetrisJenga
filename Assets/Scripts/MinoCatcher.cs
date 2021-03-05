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
        if (Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RayCheck();
            PositionCheck();
        }

        if (beRay) {
            MovePosition();
        }
        else if (!beRay) {
            target = null;
        }

        if (Input.GetMouseButtonUp(0)) {
            beRay = false;
        }
    }

    void RayCheck() {
        if (Physics.Raycast(ray, out hit)) {
            target = hit.collider.gameObject;
            if (target.CompareTag("Mino") || target.CompareTag("BottomMino")) {
                if (GameObject.FindWithTag("SelectedMino") == null) {
                    target.tag = "SelectedMino";
                    target.GetComponent<Renderer>().material.color = Color.white;
                    beRay = true;
                }
                else {
                    Debug.Log("一度移動させたミノ以外を操作することはできません");
                    beRay = false;
                }
            }
            else if (target.CompareTag("SelectedMino") || target.CompareTag("StackedMino")) {
                beRay = true;
            }
        }
        else {
            beRay = false;
        }
    }

    void PositionCheck() {
        if (target != null) {
            Vector3 mousePos = Input.mousePosition;
            float depth = Camera.main.transform.InverseTransformPoint(hit.point).z;
            mousePos.z = depth;
            targetPos = target.transform.position;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            offset = targetPos - worldMousePos;
        }
    }

    void MovePosition() {
        Vector3 mousePos = Input.mousePosition;
        float depth = Camera.main.transform.InverseTransformPoint(hit.point).z;
        mousePos.z = depth;
        Vector3 moveTo = Camera.main.ScreenToWorldPoint(mousePos);
        if ((target.transform.position.x < -6 || target.transform.position.x > 6 || target.transform.position.z < -6 || target.transform.position.z > 6) || target.CompareTag("StackedMino")) {
            target.tag = "StackedMino";
            target.GetComponent<Rigidbody>().isKinematic = true;
            target.GetComponent<Rigidbody>().MovePosition(new Vector3(moveTo.x + offset.x, moveTo.y + offset.y, moveTo.z + offset.z));
        }
        else {
            target.GetComponent<Rigidbody>().MovePosition(new Vector3(moveTo.x + offset.x, targetPos.y, moveTo.z + offset.z));
        }
    }
}
