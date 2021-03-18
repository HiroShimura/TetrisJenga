using UnityEngine;

public class MinoCatcher : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    bool beRay = false;
    GameObject target;
    Vector3 targetPos;
    Vector3 offset;
    JengaController layers;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RayCheck();
            PositionCheck();
        }

        if (beRay) MovePosition();

        if (Input.GetMouseButtonUp(0)) beRay = false;

        GameObject stackedMino = GameObject.FindWithTag("StackedMino");
        if (stackedMino == null) return;

        else if (Input.GetKeyDown(KeyCode.Space)) {
            stackedMino.GetComponent<Rigidbody>().isKinematic = false;
            stackedMino.tag = "Mino";
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) stackedMino.transform.Rotate(0, 0, 45);
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) stackedMino.transform.Rotate(0, -45, 0);
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) stackedMino.transform.Rotate(0, 0, -45);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) stackedMino.transform.Rotate(0, 45, 0);
    }

    void RayCheck() {
        if (Physics.Raycast(ray, out hit)) {
            target = hit.collider.gameObject;
            if (target.CompareTag("Mino") || target.CompareTag("BottomMino")) {
                if (GameObject.FindWithTag("SelectedMino") == null && (GameObject.FindWithTag("StackedMino") == null)) {
                    target.tag = "SelectedMino";
                    target.GetComponent<Renderer>().material.color = Color.white;
                    target.GetComponent<Rigidbody>().isKinematic = true;
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
            target = null;
            beRay = false;
            Debug.Log("ミノを選択してください");
        }
    }

    void PositionCheck() {
        if (target == null) return;

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
        if (target.transform.position.x < -4
            || target.transform.position.x > 4
            || target.transform.position.z < -4
            || target.transform.position.z > 4
            || target.CompareTag("StackedMino")) {
            target.tag = "StackedMino";
            target.GetComponent<Rigidbody>().isKinematic = true;
            target.GetComponent<Rigidbody>().MovePosition(new Vector3(moveTo.x + offset.x, moveTo.y + offset.y, moveTo.z + offset.z));
        }
        else {
            target.GetComponent<Rigidbody>().MovePosition(new Vector3(moveTo.x + offset.x, targetPos.y, moveTo.z + offset.z));
        }
    }
}
