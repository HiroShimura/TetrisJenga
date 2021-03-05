using System.Collections.Generic;
using UnityEngine;

public class JengaController : MonoBehaviour {
    public GameObject tMinoPrefab;
    public GameObject iMinoPrefab;
    public GameObject oMinoPrefab;
    public GameObject sMinoPrefab;
    public GameObject zMinoPrefab;
    public GameObject jMinoPrefab;
    public GameObject lMinoPrefab;

    [field: SerializeField, Range(4, 12)]
    public int Layers { get; set; }
    public GameObject SelectedMino { get; set; }

    List<char> direction = new List<char> { 'N', 'E', 'W', 'S' };

    // Start is called before the first frame update
    void Start() {
        int random = Random.Range(0, 4);
        for (int i = 1; i < Layers + 1; i++) {
            float high = (i - 0.5f) * 1.01f;
            int type = 1;// Random.Range(1, 11);
            switch (type) {
                case 1:
                    Type1(direction[random], high, i);
                    break;
                case 2:
                    Type2(direction[random], high, i);
                    break;
                case 3:
                    Type3(direction[random], high, i);
                    break;
                case 4:
                    Type4(direction[random], high, i);
                    break;
                case 5:
                    Type5(direction[random], high, i);
                    break;
                case 6:
                    Type6(direction[random], high, i);
                    break;
                case 7:
                    Type7(direction[random], high, i);
                    break;
                case 8:
                    Type8(direction[random], high, i);
                    break;
                case 9:
                    Type9(direction[random], high, i);
                    break;
                case 10:
                    Type10(direction[random], high, i);
                    break;
                /*
case 11:
Type11(direction[random], high, i);
break;
case 12:
Type12(direction[random], high, i);
break;
case 13:
Type13(direction[random], high, i);
break;
*/
                default:
                    break;
            }
            if (direction.Count == 4) {
                direction.RemoveAt(random);
                random = Random.Range(0, 3);
            }
            else if (direction.Count == 3) {
                direction.RemoveAt(random);
                random = Random.Range(0, 2);
            }
            else {
                direction = new List<char> { 'N', 'E', 'W', 'S' };
                random = Random.Range(0, 4);
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }

    void Type1(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠
        // ▲ ○ △ △
        // ▲ ○ ○ △
        // ▲ ▲ ○ △
        GameObject iMino = Instantiate(iMinoPrefab);
        iMino.name = $"{layer}_1";
        GameObject lMino1 = Instantiate(lMinoPrefab);
        lMino1.name = $"{layer}_2";
        GameObject sMino = Instantiate(sMinoPrefab);
        sMino.name = $"{layer}_3";
        GameObject lMino2 = Instantiate(lMinoPrefab);
        lMino2.name = $"{layer}_4";
        if (layer == 1) {
            iMino.tag = "BottomMino";
            lMino1.tag = "BottomMino";
            sMino.tag = "BottomMino";
            lMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino1.transform.position = new Vector3(-0.5f, high, -1);
                lMino1.transform.Rotate(0, 180, 0);
                sMino.transform.position = new Vector3(-0.5f, high, 0);
                sMino.transform.Rotate(0, 270, 0);
                lMino2.transform.position = new Vector3(-0.5f, high, 1);
                lMino2.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino1.transform.position = new Vector3(-1, high, 0.5f);
                lMino1.transform.Rotate(0, 270, 0);
                sMino.transform.position = new Vector3(0, high, 0.5f);
                sMino.transform.Rotate(0, 0, 0);
                lMino2.transform.position = new Vector3(1, high, 0.5f);
                lMino2.transform.Rotate(0, 90, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino1.transform.position = new Vector3(-1, high, -0.5f);
                lMino1.transform.Rotate(0, 270, 0);
                sMino.transform.position = new Vector3(0, high, -0.5f);
                sMino.transform.Rotate(0, 0, 0);
                lMino2.transform.position = new Vector3(1, high, -0.5f);
                lMino2.transform.Rotate(0, 90, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino1.transform.position = new Vector3(0.5f, high, -1);
                lMino1.transform.Rotate(0, 180, 0);
                sMino.transform.position = new Vector3(0.5f, high, 0);
                sMino.transform.Rotate(0, 270, 0);
                lMino2.transform.position = new Vector3(0.5f, high, 1);
                lMino2.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
    }
    void Type2(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠ 
        // ■ ■ ◇ □
        // ■ ◇ ◇ □
        // ■ ◇ □ □
        GameObject iMino = Instantiate(iMinoPrefab);
        iMino.name = $"{layer}_1";
        GameObject jMino1 = Instantiate(jMinoPrefab);
        jMino1.name = $"{layer}_2";
        GameObject zMino = Instantiate(zMinoPrefab);
        zMino.name = $"{layer}_3";
        GameObject jMino2 = Instantiate(jMinoPrefab);
        jMino2.name = $"{layer}_4";
        if (layer == 1) {
            iMino.tag = "BottomMino";
            jMino1.tag = "BottomMino";
            zMino.tag = "BottomMino";
            jMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino1.transform.position = new Vector3(-0.5f, high, -1);
                jMino1.transform.Rotate(0, 0, 0);
                zMino.transform.position = new Vector3(-0.5f, high, 0);
                zMino.transform.Rotate(0, 90, 0);
                jMino2.transform.position = new Vector3(-0.5f, high, 1);
                jMino2.transform.Rotate(0, 180, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(-1, high, 0.5f);
                jMino1.transform.Rotate(0, 90, 0);
                zMino.transform.position = new Vector3(0, high, 0.5f);
                zMino.transform.Rotate(0, 0, 0);
                jMino2.transform.position = new Vector3(1, high, 0.5f);
                jMino2.transform.Rotate(0, 270, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(-1, high, -0.5f);
                jMino1.transform.Rotate(0, 90, 0);
                zMino.transform.position = new Vector3(0, high, -0.5f);
                zMino.transform.Rotate(0, 0, 0);
                jMino2.transform.position = new Vector3(1, high, -0.5f);
                jMino2.transform.Rotate(0, 270, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino1.transform.position = new Vector3(0.5f, high, -1);
                jMino1.transform.Rotate(0, 0, 0);
                zMino.transform.position = new Vector3(0.5f, high, 0);
                zMino.transform.Rotate(0, 90, 0);
                jMino2.transform.position = new Vector3(0.5f, high, 1);
                jMino2.transform.Rotate(0, 180, 0);
                break;
            default:
                break;
        }
    }
    void Type3(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠
        // □ □ ○ ○
        // □ ○ ○ △
        // □ △ △ △
        GameObject iMino = Instantiate(iMinoPrefab);
        iMino.name = $"{layer}_1";
        GameObject sMino = Instantiate(sMinoPrefab);
        sMino.name = $"{layer}_2";
        GameObject lMino = Instantiate(lMinoPrefab);
        lMino.name = $"{layer}_3";
        GameObject jMino = Instantiate(jMinoPrefab);
        jMino.name = $"{layer}_4";
        if (layer == 1) {
            iMino.tag = "BottomMino";
            sMino.tag = "BottomMino";
            lMino.tag = "BottomMino";
            jMino.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                sMino.transform.position = new Vector3(0, high, -0.5f);
                sMino.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(-1, high, -0.5f);
                lMino.transform.Rotate(0, 270, 0);
                jMino.transform.position = new Vector3(-0.5f, high, 1);
                jMino.transform.Rotate(0, 180, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                sMino.transform.position = new Vector3(-0.5f, high, 0);
                sMino.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(-0.5f, high, 1);
                lMino.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(1, high, 0.5f);
                jMino.transform.Rotate(0, 270, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                sMino.transform.position = new Vector3(0.5f, high, 0);
                sMino.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(0.5f, high, -1);
                lMino.transform.Rotate(0, 180, 0);
                jMino.transform.position = new Vector3(-1, high, -0.5f);
                jMino.transform.Rotate(0, 90, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                sMino.transform.position = new Vector3(0, high, 0.5f);
                sMino.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(1, high, 0.5f);
                lMino.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(0.5f, high, -1);
                jMino.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
    }
    void Type4(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠
        // ◇ ◇ △ △
        // □ ◇ ◇ △
        // □ □ □ △
        GameObject iMino = Instantiate(iMinoPrefab);
        iMino.name = $"{layer}_1";
        GameObject lMino = Instantiate(lMinoPrefab);
        lMino.name = $"{layer}_2";
        GameObject jMino = Instantiate(jMinoPrefab);
        jMino.name = $"{layer}_3";
        GameObject zMino = Instantiate(zMinoPrefab);
        zMino.name = $"{layer}_4";
        if (layer == 1) {
            iMino.tag = "BottomMino";
            lMino.tag = "BottomMino";
            jMino.tag = "BottomMino";
            zMino.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(-0.5f, high, -1);
                lMino.transform.Rotate(0, 180, 0);
                jMino.transform.position = new Vector3(-1, high, 0.5f);
                jMino.transform.Rotate(0, 90, 0);
                zMino.transform.position = new Vector3(0, high, 0.5f);
                zMino.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(-1, high, 0.5f);
                lMino.transform.Rotate(0, 270, 0);
                jMino.transform.position = new Vector3(0.5f, high, 1);
                jMino.transform.Rotate(0, 180, 0);
                zMino.transform.position = new Vector3(0.5f, high, 0);
                zMino.transform.Rotate(0, 90, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(1, high, -0.5f);
                lMino.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(-0.5f, high, -1);
                jMino.transform.Rotate(0, 0, 0);
                zMino.transform.position = new Vector3(-0.5f, high, 0);
                zMino.transform.Rotate(0, 90, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(0.5f, high, 1);
                lMino.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(1, high, -0.5f);
                jMino.transform.Rotate(0, 270, 0);
                zMino.transform.position = new Vector3(0, high, -0.5f);
                zMino.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
    }
    void Type5(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠
        // ＆ ＆ △ △
        // ＆ ＆ ▲ △
        // ▲ ▲ ▲ △
        GameObject iMino = Instantiate(iMinoPrefab);
        iMino.name = $"{layer}_1";
        GameObject lMino1 = Instantiate(lMinoPrefab);
        lMino1.name = $"{layer}_2";
        GameObject lMino2 = Instantiate(lMinoPrefab);
        lMino2.name = $"{layer}_3";
        GameObject oMino = Instantiate(oMinoPrefab);
        oMino.name = $"{layer}_4";
        if (layer == 1) {
            iMino.tag = "BottomMino";
            lMino1.tag = "BottomMino";
            lMino2.tag = "BottomMino";
            oMino.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino1.transform.position = new Vector3(-0.5f, high, -1);
                lMino1.transform.Rotate(0, 180, 0);
                lMino2.transform.position = new Vector3(-1, high, 0.5f);
                lMino2.transform.Rotate(0, 270, 0);
                oMino.transform.position = new Vector3(0, high, 1);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino1.transform.position = new Vector3(-1, high, 0.5f);
                lMino1.transform.Rotate(0, 270, 0);
                lMino2.transform.position = new Vector3(0.5f, high, 1);
                lMino2.transform.Rotate(0, 0, 0);
                oMino.transform.position = new Vector3(1, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino1.transform.position = new Vector3(1, high, -0.5f);
                lMino1.transform.Rotate(0, 90, 0);
                lMino2.transform.position = new Vector3(-0.5f, high, -1);
                lMino2.transform.Rotate(0, 180, 0);
                oMino.transform.position = new Vector3(-1, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino1.transform.position = new Vector3(0.5f, high, 1);
                lMino1.transform.Rotate(0, 0, 0);
                lMino2.transform.position = new Vector3(1, high, -0.5f);
                lMino2.transform.Rotate(0, 90, 0);
                oMino.transform.position = new Vector3(0, high, -1);
                oMino.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
    }
    void Type6(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠
        // □ □ ＆ ＆
        // □ ■ ＆ ＆
        // □ ■ ■ ■
        GameObject iMino = Instantiate(iMinoPrefab);
        iMino.name = $"{layer}_1";
        GameObject jMino1 = Instantiate(jMinoPrefab);
        jMino1.name = $"{layer}_2";
        GameObject jMino2 = Instantiate(jMinoPrefab);
        jMino2.name = $"{layer}_3";
        GameObject oMino = Instantiate(oMinoPrefab);
        oMino.name = $"{layer}_4";
        if (layer == 1) {
            iMino.tag = "BottomMino";
            jMino1.tag = "BottomMino";
            jMino2.tag = "BottomMino";
            oMino.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino1.transform.position = new Vector3(-0.5f, high, 1);
                jMino1.transform.Rotate(0, 180, 0);
                jMino2.transform.position = new Vector3(-1, high, -0.5f);
                jMino2.transform.Rotate(0, 90, 0);
                oMino.transform.position = new Vector3(0, high, -1);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(1, high, 0.5f);
                jMino1.transform.Rotate(0, 270, 0);
                jMino2.transform.position = new Vector3(-0.5f, high, 1);
                jMino2.transform.Rotate(0, 180, 0);
                oMino.transform.position = new Vector3(-1, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(-1, high, -0.5f);
                jMino1.transform.Rotate(0, 90, 0);
                jMino2.transform.position = new Vector3(0.5f, high, -1);
                jMino2.transform.Rotate(0, 0, 0);
                oMino.transform.position = new Vector3(1, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino1.transform.position = new Vector3(0.5f, high, -1);
                jMino1.transform.Rotate(0, 0, 0);
                jMino2.transform.position = new Vector3(1, high, 0.5f);
                jMino2.transform.Rotate(0, 270, 0);
                oMino.transform.position = new Vector3(0, high, 1);
                oMino.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
    }
    void Type7(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠
        // ★ □ □ □
        // ★ ★ ☆ □
        // ★ ☆ ☆ ☆
        GameObject iMino = Instantiate(iMinoPrefab);
        iMino.name = $"{layer}_1";
        GameObject jMino = Instantiate(jMinoPrefab);
        jMino.name = $"{layer}_2";
        GameObject tMino1 = Instantiate(tMinoPrefab);
        tMino1.name = $"{layer}_3";
        GameObject tMino2 = Instantiate(tMinoPrefab);
        tMino2.name = $"{layer}_4";
        if (layer == 1) {
            iMino.tag = "BottomMino";
            jMino.tag = "BottomMino";
            tMino1.tag = "BottomMino";
            tMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(0, high, -0.5f);
                jMino.transform.Rotate(0, 270, 0);
                tMino1.transform.position = new Vector3(-1.5f, high, -0.5f);
                tMino1.transform.Rotate(0, 180, 0);
                tMino2.transform.position = new Vector3(-0.5f, high, 1.5f);
                tMino2.transform.Rotate(0, 270, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(-0.5f, high, 0);
                jMino.transform.Rotate(0, 0, 0);
                tMino1.transform.position = new Vector3(-0.5f, high, 1.5f);
                tMino1.transform.Rotate(0, 270, 0);
                tMino2.transform.position = new Vector3(1.5f, high, 0.5f);
                tMino2.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(0.5f, high, 0);
                jMino.transform.Rotate(0, 180, 0);
                tMino1.transform.position = new Vector3(0.5f, high, -1.5f);
                tMino1.transform.Rotate(0, 90, 0);
                tMino2.transform.position = new Vector3(-1.5f, high, -0.5f);
                tMino2.transform.Rotate(0, 180, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(0, high, 0.5f);
                jMino.transform.Rotate(0, 90, 0);
                tMino1.transform.position = new Vector3(1.5f, high, 0.5f);
                tMino1.transform.Rotate(0, 0, 0);
                tMino2.transform.position = new Vector3(0.5f, high, -1.5f);
                tMino2.transform.Rotate(0, 90, 0);
                break;
            default:
                break;
        }
    }
    void Type8(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠
        // △ △ △ ★
        // △ ☆ ★ ★
        // ☆ ☆ ☆ ★
        GameObject iMino = Instantiate(iMinoPrefab);
        iMino.name = $"{layer}_1";
        GameObject lMino = Instantiate(lMinoPrefab);
        lMino.name = $"{layer}_2";
        GameObject tMino1 = Instantiate(tMinoPrefab);
        tMino1.name = $"{layer}_3";
        GameObject tMino2 = Instantiate(tMinoPrefab);
        tMino2.name = $"{layer}_4";
        if (layer == 1) {
            iMino.tag = "BottomMino";
            lMino.tag = "BottomMino";
            tMino1.tag = "BottomMino";
            tMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                tMino1.transform.position = new Vector3(-0.5f, high, -1.5f);
                tMino1.transform.Rotate(0, 90, 0);
                tMino2.transform.position = new Vector3(-1.5f, high, 0.5f);
                tMino2.transform.Rotate(0, 180, 0);
                lMino.transform.position = new Vector3(0, high, 0.5f);
                lMino.transform.Rotate(0, 90, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                tMino1.transform.position = new Vector3(-1.5f, high, 0.5f);
                tMino1.transform.Rotate(0, 180, 0);
                tMino2.transform.position = new Vector3(0.5f, high, 1.5f);
                tMino2.transform.Rotate(0, 270, 0);
                lMino.transform.position = new Vector3(0.5f, high, 0);
                lMino.transform.Rotate(0, 180, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                tMino1.transform.position = new Vector3(1.5f, high, -0.5f);
                tMino1.transform.Rotate(0, 00, 0);
                tMino2.transform.position = new Vector3(-0.5f, high, -1.5f);
                tMino2.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(-0.5f, high, 0);
                lMino.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                tMino1.transform.position = new Vector3(0.5f, high, 1.5f);
                tMino1.transform.Rotate(0, 270, 0);
                tMino2.transform.position = new Vector3(1.5f, high, -0.5f);
                tMino2.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(0, high, -0.5f);
                lMino.transform.Rotate(0, 270, 0);
                break;
            default:
                break;
        }
    }
    void Type9(char direction, float high, int layer) {
        // △ △ △ ★
        // △ ◇ ★ ★
        // ◇ ◇ ☆ ★
        // ◇ ☆ ☆ ☆
        GameObject lMino = Instantiate(lMinoPrefab);
        lMino.name = $"{layer}_1";
        GameObject tMino1 = Instantiate(tMinoPrefab);
        tMino1.name = $"{layer}_2";
        GameObject tMino2 = Instantiate(tMinoPrefab);
        tMino2.name = $"{layer}_3";
        GameObject zMino = Instantiate(zMinoPrefab);
        zMino.name = $"{layer}_4";
        if (layer == 1) {
            lMino.tag = "BottomMino";
            tMino1.tag = "BottomMino";
            tMino2.tag = "BottomMino";
            zMino.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                lMino.transform.position = new Vector3(1, high, 0.5f);
                lMino.transform.Rotate(0, 90, 0);
                tMino1.transform.position = new Vector3(0.5f, high, -1.5f);
                tMino1.transform.Rotate(0, 90, 0);
                tMino2.transform.position = new Vector3(-1.5f, high, -0.5f);
                tMino2.transform.Rotate(0, 180, 0);
                zMino.transform.position = new Vector3(-0.5f, high, 1);
                zMino.transform.Rotate(0, 90, 0);
                break;
            case 'E':
                lMino.transform.position = new Vector3(0.5f, high, -1);
                lMino.transform.Rotate(0, 180, 0);
                tMino1.transform.position = new Vector3(-1.5f, high, -0.5f);
                tMino1.transform.Rotate(0, 180, 0);
                tMino2.transform.position = new Vector3(-0.5f, high, 1.5f);
                tMino2.transform.Rotate(0, 270, 0);
                zMino.transform.position = new Vector3(1, high, 0.5f);
                zMino.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                lMino.transform.position = new Vector3(-0.5f, high, 1);
                lMino.transform.Rotate(0, 0, 0);
                tMino1.transform.position = new Vector3(1.5f, high, 0.5f);
                tMino1.transform.Rotate(0, 0, 0);
                tMino2.transform.position = new Vector3(0.5f, high, -1.5f);
                tMino2.transform.Rotate(0, 90, 0);
                zMino.transform.position = new Vector3(-1, high, -0.5f);
                zMino.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                lMino.transform.position = new Vector3(-1, high, -0.5f);
                lMino.transform.Rotate(0, 270, 0);
                tMino1.transform.position = new Vector3(-0.5f, high, 1.5f);
                tMino1.transform.Rotate(0, 270, 0);
                tMino2.transform.position = new Vector3(1.5f, high, 0.5f);
                tMino2.transform.Rotate(0, 0, 0);
                zMino.transform.position = new Vector3(0.5f, high, -1);
                zMino.transform.Rotate(0, 90, 0);
                break;
            default:
                break;
        }
    }
    void Type10(char direction, float high, int layer) {
        // ★ □ □ □
        // ★ ★ ○ □
        // ★ ☆ ○ ○
        // ☆ ☆ ☆ ○
        GameObject tMino1 = Instantiate(tMinoPrefab);
        tMino1.name = $"{layer}_1";
        GameObject jMino = Instantiate(jMinoPrefab);
        jMino.name = $"{layer}_2";
        GameObject sMino = Instantiate(sMinoPrefab);
        sMino.name = $"{layer}_3";
        GameObject tMino2 = Instantiate(tMinoPrefab);
        tMino2.name = $"{layer}_4";
        if (layer == 1) {
            tMino1.tag = "BottomMino";
            jMino.tag = "BottomMino";
            sMino.tag = "BottomMino";
            tMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                tMino1.transform.position = new Vector3(0.5f, high, 1.5f);
                tMino1.transform.Rotate(0, 270, 0);
                jMino.transform.position = new Vector3(1, high, -0.5f);
                jMino.transform.Rotate(0, 270, 0);
                sMino.transform.position = new Vector3(-0.5f, high, -1);
                sMino.transform.Rotate(0, 90, 0);
                tMino2.transform.position = new Vector3(-1.5f, high, 0.5f);
                tMino2.transform.Rotate(0, 180, 0);
                break;
            case 'E':
                tMino1.transform.position = new Vector3(1.5f, high, -0.5f);
                tMino1.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(-0.5f, high, -1);
                jMino.transform.Rotate(0, 0, 0);
                sMino.transform.position = new Vector3(-1, high, 0.5f);
                sMino.transform.Rotate(0, 0, 0);
                tMino2.transform.position = new Vector3(0.5f, high, 1.5f);
                tMino2.transform.Rotate(0, 270, 0);
                break;
            case 'W':
                tMino1.transform.position = new Vector3(-1.5f, high, 0.5f);
                tMino1.transform.Rotate(0, 180, 0);
                jMino.transform.position = new Vector3(0.5f, high, 1);
                jMino.transform.Rotate(0, 180, 0);
                sMino.transform.position = new Vector3(1, high, -0.5f);
                sMino.transform.Rotate(0, 0, 0);
                tMino2.transform.position = new Vector3(-0.5f, high, -1.5f);
                tMino2.transform.Rotate(0, 90, 0);
                break;
            case 'S':
                tMino1.transform.position = new Vector3(-0.5f, high, -1.5f);
                tMino1.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(-1, high, 0.5f);
                jMino.transform.Rotate(0, 90, 0);
                sMino.transform.position = new Vector3(0.5f, high, 1);
                sMino.transform.Rotate(0, 270, 0);
                tMino2.transform.position = new Vector3(1.5f, high, -0.5f);
                tMino2.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
    }
    void Type11(char direction, float high, int layer) {
        /*
        // △ △ △ ◇
        // △ ◆ ◇ ◇
        // ◆ ◆ ◇ ▲
        // ◆ ▲ ▲ ▲
        GameObject ;
        GameObject ;
        GameObject ;
        GameObject ;
                if (layer == 1) {
            iMino.tag = "BottomMino";
            lMino1.tag = "BottomMino";
            sMino.tag = "BottomMino";
            lMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':

                break;
            case 'E':

                break;
            case 'W':

                break;
            case 'S':

                break;
            default:
                break;
        }
        */
    }
    void Type12(char direction, float high, int layer) {
        /*
        // ○ □ □ □
        // ○ ○ ● □
        // ■ ○ ● ●
        // ■ ■ ■ ●
        GameObject ;
        GameObject ;
        GameObject ;
        GameObject ;
                if (layer == 1) {
            iMino.tag = "BottomMino";
            lMino1.tag = "BottomMino";
            sMino.tag = "BottomMino";
            lMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':

                break;
            case 'E':

                break;
            case 'W':

                break;
            case 'S':

                break;
            default:
                break;
        }
        */
    }
    void Type13(char direction, float high, int layer) {
        /*
        // ＠ ＠ ＠ ＠
        // △ ＆ ＆ □
        // △ ＆ ＆ □
        // △ △ □ □
        GameObject ;
        GameObject ;
        GameObject ;
        GameObject ;
                if (layer == 1) {
            iMino.tag = "BottomMino";
            lMino1.tag = "BottomMino";
            sMino.tag = "BottomMino";
            lMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':

                break;
            case 'E':

                break;
            case 'W':

                break;
            case 'S':

                break;
            default:
                break;
        }
        */
    }

    private void OnDestroy() {
        // Debug.Log(SelectedMino.name);
    }
}
