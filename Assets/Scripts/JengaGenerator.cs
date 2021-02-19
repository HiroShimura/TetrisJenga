using UnityEngine;

public class JengaGenerator : MonoBehaviour {
    public GameObject tMinoPrefab;
    public GameObject iMinoPrefab;
    public GameObject oMinoPrefab;
    public GameObject sMinoPrefab;
    public GameObject zMinoPrefab;
    public GameObject jMinoPrefab;
    public GameObject lMinoPrefab;
    // Start is called before the first frame update
    void Start() {

    }

    void Type1(Vector3 rotatePos, float rotate) {
        GameObject iMino1_1 = Instantiate(iMinoPrefab);
        iMino1_1.transform.position = new Vector3(1.5f, 1, 0);
        iMino1_1.transform.Rotate(0, 90 + rotate, 0);

        GameObject lMino1_1 = Instantiate(lMinoPrefab);
        lMino1_1.transform.position = new Vector3(-0.5f, 1, -1);
        lMino1_1.transform.Rotate(0, 180 + rotate, 0);

        GameObject sMino1_1 = Instantiate(sMinoPrefab);
        sMino1_1.transform.position = new Vector3(-0.5f, 1, 0);
        sMino1_1.transform.Rotate(0, 270 + rotate, 0);

        GameObject lMino1_2 = Instantiate(lMinoPrefab);
        lMino1_2.transform.position = new Vector3(-0.5f, 1, 1);
        lMino1_2.transform.Rotate(0, rotate, 0);
    }

    // Update is called once per frame
    void Update() {

    }
}
