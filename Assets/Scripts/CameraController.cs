using UnityEngine;

/// <summary>
/// GameビューにてSceneビューのようなカメラの動きをマウス操作によって実現する
/// </summary>
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    [SerializeField, Range(0.1f, 10f)]
    private float wheelSpeed = 1f;

    [SerializeField, Range(0.1f, 10f)]
    private float moveSpeed = 0.3f;

    [SerializeField, Range(0.1f, 10f)]
    private float rotateSpeed = 0.3f;

    private Vector3 preMousePos;

    void Update() {
        MouseUpdate();
    }

    void MouseUpdate() {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0f) {
            MouseWheel(scrollWheel);
        }
        if (Input.GetMouseButtonDown(0) ||
           Input.GetMouseButtonDown(1) ||
           Input.GetMouseButtonDown(2)) {
            preMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1) ||
           Input.GetMouseButtonUp(2)) {
            Cursor.visible = true;
        }
        MouseDrag(Input.mousePosition);
    }

    void MouseWheel(float delta) {
        transform.position += transform.forward * delta * wheelSpeed;
        return;
    }

    void MouseDrag(Vector3 mousePos) {
        Vector3 diff = mousePos - preMousePos;
        if (diff.magnitude < Vector3.kEpsilon) {
            return;
        }
        if (Input.GetMouseButton(2)) {
            Cursor.visible = false;
            transform.Translate(-diff * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetMouseButton(1)) {
            Cursor.visible = false;
            CameraRotate(new Vector2(-diff.y, diff.x) * rotateSpeed);
        }
        preMousePos = mousePos;
    }

    public void CameraRotate(Vector2 angle) {
        Vector3 focusObjectPos = new Vector3(0, 0, 0);
        transform.RotateAround(focusObjectPos, transform.right, angle.x);
        transform.RotateAround(focusObjectPos, Vector3.up, angle.y);
    }
}
