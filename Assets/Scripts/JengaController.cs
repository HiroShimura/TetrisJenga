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
    [SerializeField] GameObject table;

    public int Layers {
        get; set;
    }

    List<char> direction = new List<char> { 'N', 'E', 'W', 'S' };

    void Awake() {
        int random = Random.Range(0, 4); // 向きを決める乱数
        Layers = 1; // PlayerPrefs.GetInt("Layer", 8); // オプションで設定した段数を代入
        for (int i = 1; i < Layers + 1; i++) {
            float high = i * 0.15f + 0.7f; // 生成する高さを決定
            int type = Random.Range(1, 11); // どのタイプを積むのかを選定
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
                case 11:
                    Type11(direction[random], high, i);
                    break;
                case 12:
                    Type12(direction[random], high, i);
                    break;
                case 13:
                    Type13(direction[random], high, i);
                    break;
                default:
                    break;
            }

            // 方向がなるべく被らないように乱数を絞る
            if (direction.Count == 4) {
                direction.RemoveAt(random);
                random = Random.Range(0, 3);
            }
            else if (direction.Count == 3) {
                direction.RemoveAt(random);
                random = Random.Range(0, 2);
            }
            else {
                direction = new List<char> { 'N', 'E', 'W', 'S' }; // リストの再作成
                random = Random.Range(0, 4);
            }
        }
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
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino1.transform.position = new Vector3(-0.5f, high, -1f);
                lMino1.transform.Rotate(0, 180, 0);
                sMino.transform.position = new Vector3(-0.5f, high, 0);
                sMino.transform.Rotate(0, 270, 0);
                lMino2.transform.position = new Vector3(-0.5f, high, 1f);
                lMino2.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino1.transform.position = new Vector3(-1f, high, 0.5f);
                lMino1.transform.Rotate(0, 270, 0);
                sMino.transform.position = new Vector3(0, high, 0.5f);
                sMino.transform.Rotate(0, 0, 0);
                lMino2.transform.position = new Vector3(1f, high, 0.5f);
                lMino2.transform.Rotate(0, 90, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino1.transform.position = new Vector3(-1f, high, -0.5f);
                lMino1.transform.Rotate(0, 270, 0);
                sMino.transform.position = new Vector3(0, high, -0.5f);
                sMino.transform.Rotate(0, 0, 0);
                lMino2.transform.position = new Vector3(1f, high, -0.5f);
                lMino2.transform.Rotate(0, 90, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino1.transform.position = new Vector3(0.5f, high, -1f);
                lMino1.transform.Rotate(0, 180, 0);
                sMino.transform.position = new Vector3(0.5f, high, 0);
                sMino.transform.Rotate(0, 270, 0);
                lMino2.transform.position = new Vector3(0.5f, high, 1f);
                lMino2.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
        if (layer == 1) {
            iMino.tag = "BottomMino";
            lMino1.tag = "BottomMino";
            sMino.tag = "BottomMino";
            lMino2.tag = "BottomMino";
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
                jMino1.transform.position = new Vector3(-0.5f, high, -1f);
                jMino1.transform.Rotate(0, 0, 0);
                zMino.transform.position = new Vector3(-0.5f, high, 0);
                zMino.transform.Rotate(0, 90, 0);
                jMino2.transform.position = new Vector3(-0.5f, high, 1f);
                jMino2.transform.Rotate(0, 180, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(-1f, high, 0.5f);
                jMino1.transform.Rotate(0, 90, 0);
                zMino.transform.position = new Vector3(0, high, 0.5f);
                zMino.transform.Rotate(0, 0, 0);
                jMino2.transform.position = new Vector3(1f, high, 0.5f);
                jMino2.transform.Rotate(0, 270, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(-1f, high, -0.5f);
                jMino1.transform.Rotate(0, 90, 0);
                zMino.transform.position = new Vector3(0, high, -0.5f);
                zMino.transform.Rotate(0, 0, 0);
                jMino2.transform.position = new Vector3(1f, high, -0.5f);
                jMino2.transform.Rotate(0, 270, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino1.transform.position = new Vector3(0.5f, high, -1f);
                jMino1.transform.Rotate(0, 0, 0);
                zMino.transform.position = new Vector3(0.5f, high, 0);
                zMino.transform.Rotate(0, 90, 0);
                jMino2.transform.position = new Vector3(0.5f, high, 1f);
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
                lMino.transform.position = new Vector3(-1f, high, -0.5f);
                lMino.transform.Rotate(0, 270, 0);
                jMino.transform.position = new Vector3(-0.5f, high, 1f);
                jMino.transform.Rotate(0, 180, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                sMino.transform.position = new Vector3(-0.5f, high, 0);
                sMino.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(-0.5f, high, 1f);
                lMino.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(1f, high, 0.5f);
                jMino.transform.Rotate(0, 270, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                sMino.transform.position = new Vector3(0.5f, high, 0);
                sMino.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(0.5f, high, -1f);
                lMino.transform.Rotate(0, 180, 0);
                jMino.transform.position = new Vector3(-1f, high, -0.5f);
                jMino.transform.Rotate(0, 90, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                sMino.transform.position = new Vector3(0, high, 0.5f);
                sMino.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(1f, high, 0.5f);
                lMino.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(0.5f, high, -1f);
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
                lMino.transform.position = new Vector3(-0.5f, high, -1f);
                lMino.transform.Rotate(0, 180, 0);
                jMino.transform.position = new Vector3(-1f, high, 0.5f);
                jMino.transform.Rotate(0, 90, 0);
                zMino.transform.position = new Vector3(0, high, 0.5f);
                zMino.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(-1f, high, 0.5f);
                lMino.transform.Rotate(0, 270, 0);
                jMino.transform.position = new Vector3(0.5f, high, 1f);
                jMino.transform.Rotate(0, 180, 0);
                zMino.transform.position = new Vector3(0.5f, high, 0);
                zMino.transform.Rotate(0, 90, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(1f, high, -0.5f);
                lMino.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(-0.5f, high, -1f);
                jMino.transform.Rotate(0, 0, 0);
                zMino.transform.position = new Vector3(-0.5f, high, 0);
                zMino.transform.Rotate(0, 90, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(0.5f, high, 1f);
                lMino.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(1f, high, -0.5f);
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
                lMino1.transform.position = new Vector3(-0.5f, high, -1f);
                lMino1.transform.Rotate(0, 180, 0);
                lMino2.transform.position = new Vector3(-1f, high, 0.5f);
                lMino2.transform.Rotate(0, 270, 0);
                oMino.transform.position = new Vector3(0, high, 1f);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino1.transform.position = new Vector3(-1f, high, 0.5f);
                lMino1.transform.Rotate(0, 270, 0);
                lMino2.transform.position = new Vector3(0.5f, high, 1f);
                lMino2.transform.Rotate(0, 0, 0);
                oMino.transform.position = new Vector3(1f, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                lMino1.transform.position = new Vector3(1f, high, -0.5f);
                lMino1.transform.Rotate(0, 90, 0);
                lMino2.transform.position = new Vector3(-0.5f, high, -1f);
                lMino2.transform.Rotate(0, 180, 0);
                oMino.transform.position = new Vector3(-1f, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                lMino1.transform.position = new Vector3(0.5f, high, 1f);
                lMino1.transform.Rotate(0, 0, 0);
                lMino2.transform.position = new Vector3(1f, high, -0.5f);
                lMino2.transform.Rotate(0, 90, 0);
                oMino.transform.position = new Vector3(0, high, -1f);
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
                jMino1.transform.position = new Vector3(-0.5f, high, 1f);
                jMino1.transform.Rotate(0, 180, 0);
                jMino2.transform.position = new Vector3(-1f, high, -0.5f);
                jMino2.transform.Rotate(0, 90, 0);
                oMino.transform.position = new Vector3(0, high, -1f);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(1f, high, 0.5f);
                jMino1.transform.Rotate(0, 270, 0);
                jMino2.transform.position = new Vector3(-0.5f, high, 1f);
                jMino2.transform.Rotate(0, 180, 0);
                oMino.transform.position = new Vector3(-1f, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(-1f, high, -0.5f);
                jMino1.transform.Rotate(0, 90, 0);
                jMino2.transform.position = new Vector3(0.5f, high, -1f);
                jMino2.transform.Rotate(0, 0, 0);
                oMino.transform.position = new Vector3(1f, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino1.transform.position = new Vector3(0.5f, high, -1f);
                jMino1.transform.Rotate(0, 0, 0);
                jMino2.transform.position = new Vector3(1f, high, 0.5f);
                jMino2.transform.Rotate(0, 270, 0);
                oMino.transform.position = new Vector3(0, high, 1f);
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
                lMino.transform.position = new Vector3(1f, high, 0.5f);
                lMino.transform.Rotate(0, 90, 0);
                tMino1.transform.position = new Vector3(0.5f, high, -1.5f);
                tMino1.transform.Rotate(0, 90, 0);
                tMino2.transform.position = new Vector3(-1.5f, high, -0.5f);
                tMino2.transform.Rotate(0, 180, 0);
                zMino.transform.position = new Vector3(-0.5f, high, 1f);
                zMino.transform.Rotate(0, 90, 0);
                break;
            case 'E':
                lMino.transform.position = new Vector3(0.5f, high, -1f);
                lMino.transform.Rotate(0, 180, 0);
                tMino1.transform.position = new Vector3(-1.5f, high, -0.5f);
                tMino1.transform.Rotate(0, 180, 0);
                tMino2.transform.position = new Vector3(-0.5f, high, 1.5f);
                tMino2.transform.Rotate(0, 270, 0);
                zMino.transform.position = new Vector3(1f, high, 0.5f);
                zMino.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                lMino.transform.position = new Vector3(-0.5f, high, 1f);
                lMino.transform.Rotate(0, 0, 0);
                tMino1.transform.position = new Vector3(1.5f, high, 0.5f);
                tMino1.transform.Rotate(0, 0, 0);
                tMino2.transform.position = new Vector3(0.5f, high, -1.5f);
                tMino2.transform.Rotate(0, 90, 0);
                zMino.transform.position = new Vector3(-1f, high, -0.5f);
                zMino.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                lMino.transform.position = new Vector3(-1f, high, -0.5f);
                lMino.transform.Rotate(0, 270, 0);
                tMino1.transform.position = new Vector3(-0.5f, high, 1.5f);
                tMino1.transform.Rotate(0, 270, 0);
                tMino2.transform.position = new Vector3(1.5f, high, 0.5f);
                tMino2.transform.Rotate(0, 0, 0);
                zMino.transform.position = new Vector3(0.5f, high, -1f);
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
                jMino.transform.position = new Vector3(1f, high, -0.5f);
                jMino.transform.Rotate(0, 270, 0);
                sMino.transform.position = new Vector3(-0.5f, high, -1f);
                sMino.transform.Rotate(0, 90, 0);
                tMino2.transform.position = new Vector3(-1.5f, high, 0.5f);
                tMino2.transform.Rotate(0, 180, 0);
                break;
            case 'E':
                tMino1.transform.position = new Vector3(1.5f, high, -0.5f);
                tMino1.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(-0.5f, high, -1f);
                jMino.transform.Rotate(0, 0, 0);
                sMino.transform.position = new Vector3(-1f, high, 0.5f);
                sMino.transform.Rotate(0, 0, 0);
                tMino2.transform.position = new Vector3(0.5f, high, 1.5f);
                tMino2.transform.Rotate(0, 270, 0);
                break;
            case 'W':
                tMino1.transform.position = new Vector3(-1.5f, high, 0.5f);
                tMino1.transform.Rotate(0, 180, 0);
                jMino.transform.position = new Vector3(0.5f, high, 1f);
                jMino.transform.Rotate(0, 180, 0);
                sMino.transform.position = new Vector3(1f, high, -0.5f);
                sMino.transform.Rotate(0, 0, 0);
                tMino2.transform.position = new Vector3(-0.5f, high, -1.5f);
                tMino2.transform.Rotate(0, 90, 0);
                break;
            case 'S':
                tMino1.transform.position = new Vector3(-0.5f, high, -1.5f);
                tMino1.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(-1f, high, 0.5f);
                jMino.transform.Rotate(0, 90, 0);
                sMino.transform.position = new Vector3(0.5f, high, 1f);
                sMino.transform.Rotate(0, 270, 0);
                tMino2.transform.position = new Vector3(1.5f, high, -0.5f);
                tMino2.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
    }
    void Type11(char direction, float high, int layer) {
        // △ △ △ ◇
        // △ ◆ ◇ ◇
        // ◆ ◆ ◇ ▲
        // ◆ ▲ ▲ ▲
        GameObject lMino1 = Instantiate(lMinoPrefab);
        GameObject zMino1 = Instantiate(zMinoPrefab);
        GameObject lMino2 = Instantiate(lMinoPrefab);
        GameObject zMino2 = Instantiate(zMinoPrefab);
        if (layer == 1) {
            lMino1.tag = "BottomMino";
            zMino1.tag = "BottomMino";
            lMino2.tag = "BottomMino";
            zMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                lMino1.transform.position = new Vector3(1f, high, 0.5f);
                lMino1.transform.Rotate(0, 90, 0);
                zMino1.transform.position = new Vector3(0.5f, high, -1f);
                zMino1.transform.Rotate(0, 90, 0);
                lMino2.transform.position = new Vector3(-1f, high, -0.5f);
                lMino2.transform.Rotate(0, 270, 0);
                zMino2.transform.position = new Vector3(-0.5f, high, 1f);
                zMino2.transform.Rotate(0, 90, 0);
                break;
            case 'E':
                lMino1.transform.position = new Vector3(0.5f, high, -1f);
                lMino1.transform.Rotate(0, 180, 0);
                zMino1.transform.position = new Vector3(-1f, high, -0.5f);
                zMino1.transform.Rotate(0, 0, 0);
                lMino2.transform.position = new Vector3(-0.5f, high, 1f);
                lMino2.transform.Rotate(0, 0, 0);
                zMino2.transform.position = new Vector3(1f, high, 0.5f);
                zMino2.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                lMino1.transform.position = new Vector3(0.5f, high, -1f);
                lMino1.transform.Rotate(0, 180, 0);
                zMino1.transform.position = new Vector3(-1f, high, -0.5f);
                zMino1.transform.Rotate(0, 0, 0);
                lMino2.transform.position = new Vector3(-0.5f, high, 1f);
                lMino2.transform.Rotate(0, 0, 0);
                zMino2.transform.position = new Vector3(1f, high, 0.5f);
                zMino2.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                lMino1.transform.position = new Vector3(1f, high, 0.5f);
                lMino1.transform.Rotate(0, 90, 0);
                zMino1.transform.position = new Vector3(0.5f, high, -1f);
                zMino1.transform.Rotate(0, 90, 0);
                lMino2.transform.position = new Vector3(-1f, high, -0.5f);
                lMino2.transform.Rotate(0, 270, 0);
                zMino2.transform.position = new Vector3(-0.5f, high, 1f);
                zMino2.transform.Rotate(0, 90, 0);
                break;
            default:
                break;
        }
    }
    void Type12(char direction, float high, int layer) {
        // ○ □ □ □
        // ○ ○ ● □
        // ■ ○ ● ●
        // ■ ■ ■ ●
        GameObject sMino1 = Instantiate(sMinoPrefab);
        GameObject jMino1 = Instantiate(jMinoPrefab);
        GameObject sMino2 = Instantiate(sMinoPrefab);
        GameObject jMino2 = Instantiate(jMinoPrefab);
        if (layer == 1) {
            sMino1.tag = "BottomMino";
            jMino1.tag = "BottomMino";
            sMino2.tag = "BottomMino";
            jMino2.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                sMino1.transform.position = new Vector3(-0.5f, high, -1f);
                sMino1.transform.Rotate(0, 90, 0);
                jMino1.transform.position = new Vector3(1f, high, -0.5f);
                jMino1.transform.Rotate(0, 270, 0);
                sMino2.transform.position = new Vector3(0.5f, high, 1f);
                sMino2.transform.Rotate(0, 90, 0);
                jMino2.transform.position = new Vector3(-1f, high, 0.5f);
                jMino2.transform.Rotate(0, 90, 0);
                break;
            case 'E':
                sMino1.transform.position = new Vector3(-1f, high, 0.5f);
                sMino1.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(-0.5f, high, -1f);
                jMino1.transform.Rotate(0, 0, 0);
                sMino2.transform.position = new Vector3(1f, high, -0.5f);
                sMino2.transform.Rotate(0, 0, 0);
                jMino2.transform.position = new Vector3(0.5f, high, 1f);
                jMino2.transform.Rotate(0, 180, 0);
                break;
            case 'W':
                sMino1.transform.position = new Vector3(-1f, high, 0.5f);
                sMino1.transform.Rotate(0, 0, 0);
                jMino1.transform.position = new Vector3(-0.5f, high, -1f);
                jMino1.transform.Rotate(0, 0, 0);
                sMino2.transform.position = new Vector3(1f, high, -0.5f);
                sMino2.transform.Rotate(0, 0, 0);
                jMino2.transform.position = new Vector3(0.5f, high, 1f);
                jMino2.transform.Rotate(0, 180, 0);
                break;
            case 'S':
                sMino1.transform.position = new Vector3(-0.5f, high, -1f);
                sMino1.transform.Rotate(0, 90, 0);
                jMino1.transform.position = new Vector3(1f, high, -0.5f);
                jMino1.transform.Rotate(0, 270, 0);
                sMino2.transform.position = new Vector3(0.5f, high, 1f);
                sMino2.transform.Rotate(0, 90, 0);
                jMino2.transform.position = new Vector3(-1f, high, 0.5f);
                jMino2.transform.Rotate(0, 90, 0);
                break;
            default:
                break;
        }
    }
    void Type13(char direction, float high, int layer) {
        // ＠ ＠ ＠ ＠
        // △ ＆ ＆ □
        // △ ＆ ＆ □
        // △ △ □ □
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject jMino = Instantiate(jMinoPrefab);
        GameObject lMino = Instantiate(lMinoPrefab);
        GameObject oMino = Instantiate(oMinoPrefab);
        if (layer == 1) {
            iMino.tag = "BottomMino";
            jMino.tag = "BottomMino";
            lMino.tag = "BottomMino";
            oMino.tag = "BottomMino";
        }
        switch (direction) {
            case 'N':
                iMino.transform.position = new Vector3(1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(-0.5f, high, -1f);
                jMino.transform.Rotate(0, 0, 0);
                lMino.transform.position = new Vector3(-0.5f, high, 1f);
                lMino.transform.Rotate(0, 0, 0);
                oMino.transform.position = new Vector3(0, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'E':
                iMino.transform.position = new Vector3(0, high, -1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(-1f, high, 0.5f);
                jMino.transform.Rotate(0, 90, 0);
                lMino.transform.position = new Vector3(1f, high, 0.5f);
                lMino.transform.Rotate(0, 90, 0);
                oMino.transform.position = new Vector3(0, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'W':
                iMino.transform.position = new Vector3(0, high, 1.5f);
                iMino.transform.Rotate(0, 0, 0);
                jMino.transform.position = new Vector3(1f, high, -0.5f);
                jMino.transform.Rotate(0, 270, 0);
                lMino.transform.position = new Vector3(-1f, high, -0.5f);
                lMino.transform.Rotate(0, 270, 0);
                oMino.transform.position = new Vector3(0, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            case 'S':
                iMino.transform.position = new Vector3(-1.5f, high, 0);
                iMino.transform.Rotate(0, 90, 0);
                jMino.transform.position = new Vector3(0.5f, high, 1f);
                jMino.transform.Rotate(0, 180, 0);
                lMino.transform.position = new Vector3(0.5f, high, -1f);
                lMino.transform.Rotate(0, 180, 0);
                oMino.transform.position = new Vector3(0, high, 0);
                oMino.transform.Rotate(0, 0, 0);
                break;
            default:
                break;
        }
    }
}
