using UnityEngine;

public class MinoController : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    bool beRay = false;
    GameObject target;
    Rigidbody targetRbCache;
    Vector3 targetPos;
    Vector3 offset;
    [SerializeField] GameObject afterSelectMinoText;

    void Update() {
        // ミノをクリックしているか、ミノとカーソルとの距離を計算
        if (Input.GetMouseButtonDown(0)) {
            afterSelectMinoText.SetActive(false);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RayCheck();
            PositionCheck();
        }

        // ミノを掴んで動かす
        if (beRay)
            MovePosition();

        // ミノを離す
        if (Input.GetMouseButtonUp(0))
            beRay = false;

        // ミノが空中にある時の操作
        if (GameObject.FindWithTag("StackedMino") == null)
            return;
        else if (Input.GetKeyDown(KeyCode.Space)) {
            targetRbCache.isKinematic = false;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            target.transform.Rotate(0, 0, 1);
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            target.transform.Rotate(0, -1, 0);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            target.transform.Rotate(0, 0, -1);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            target.transform.Rotate(0, 1, 0);
    }

    void RayCheck() {
        if (Physics.Raycast(ray, out hit)) {
            target = hit.collider.gameObject; // 選択されたミノを代入

            // 既に選択中の、または空中にミノが無いかを確認
            if (target.CompareTag("Mino") || target.CompareTag("BottomMino")) {
                if (GameObject.FindWithTag("SelectedMino") == null && (GameObject.FindWithTag("StackedMino") == null)) {
                    target.tag = "SelectedMino";
                    target.GetComponent<Renderer>().material.color = Color.white;
                    targetRbCache = target.GetComponent<Rigidbody>(); //Rigidbodyをキャッシュ
                    targetRbCache.isKinematic = true;
                    beRay = true; // ミノを掴める状態へ変更
                }
                else {
                    afterSelectMinoText.SetActive(true); // 選択したミノ以外は操作ができなくなっている注意文を表示
                    beRay = false;
                }
            }

            // 掴んだミノが選択中の、または空中のミノであれば操作可能
            else if (target.CompareTag("SelectedMino") || target.CompareTag("StackedMino")) {
                beRay = true;
            }
        }
        else {
            beRay = false;
        }
    }

    void PositionCheck() {
        if (target == null)
            return;

        Vector3 mousePos = Input.mousePosition;
        float depth = Camera.main.transform.InverseTransformPoint(hit.point).z;
        mousePos.z = depth; // マウスのpositionに仮想のz座標を代入
        targetPos = target.transform.position;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        offset = targetPos - worldMousePos;
    }

    void MovePosition() {
        if (target == null)
            return;

        Vector3 mousePos = Input.mousePosition;
        float depth = Camera.main.transform.InverseTransformPoint(hit.point).z;
        mousePos.z = depth;
        Vector3 moveTo = Camera.main.ScreenToWorldPoint(mousePos);

        // タワーからミノを抜いて、ミノの上下の移動もできる状態
        if (target.transform.position.x < -4
            || target.transform.position.x > 4
            || target.transform.position.z < -4
            || target.transform.position.z > 4
            || target.CompareTag("StackedMino")) {
            target.tag = "StackedMino";
            targetRbCache.MovePosition(new Vector3(moveTo.x + offset.x, moveTo.y + offset.y, moveTo.z + offset.z));
        }

        // まだタワーから抜ききっておらず、上下には移動させない状態
        else {
            targetRbCache.MovePosition(new Vector3(moveTo.x + offset.x, targetPos.y, moveTo.z + offset.z));
        }
    }
}
