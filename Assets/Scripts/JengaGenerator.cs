﻿using UnityEngine;

public class JengaGenerator : MonoBehaviour {
    public GameObject tMinoPrefab;
    public GameObject iMinoPrefab;
    public GameObject oMinoPrefab;
    public GameObject sMinoPrefab;
    public GameObject zMinoPrefab;
    public GameObject jMinoPrefab;
    public GameObject lMinoPrefab;

    char[] direction = { 'N', 'E', 'W', 'S' };

    // Start is called before the first frame update
    void Start() {
        for (int i = 1; i < 5; i++) {
            int random = i - 1;// Random.Range(0, 4);
            float high = (i - 0.5f) * 1.05f;
            int type = 8;// Random.Range(1, 8);
            switch (type) {
                case 1:
                    Type1(direction[random], high);
                    break;
                case 2:
                    Type2(direction[random], high);
                    break;
                case 3:
                    Type3(direction[random], high);
                    break;
                case 4:
                    Type4(direction[random], high);
                    break;
                case 5:
                    Type5(direction[random], high);
                    break;
                case 6:
                    Type6(direction[random], high);
                    break;
                case 7:
                    Type7(direction[random], high);
                    break;
                case 8:
                    Type8(direction[random], high);
                    break;
                /*

case 9:
Type9(direction[random], high);
break;
case 10:
Type10(direction[random], high);
break;
case 11:
Type11(direction[random], high);
break;
case 12:
Type12(direction[random], high);
break;
case 13:
Type13(direction[random], high);
break;
*/
                default:
                    break;
            }
        }
    }

    void Type1(char direction, float high) {
        //
        //
        //
        //
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject lMino1 = Instantiate(lMinoPrefab);
        GameObject sMino = Instantiate(sMinoPrefab);
        GameObject lMino2 = Instantiate(lMinoPrefab);
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
    void Type2(char direction, float high) {
        //
        //
        //
        //
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject jMino1 = Instantiate(jMinoPrefab);
        GameObject zMino = Instantiate(zMinoPrefab);
        GameObject jMino2 = Instantiate(jMinoPrefab);
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
    void Type3(char direction, float high) {
        //
        //
        //
        //
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject sMino = Instantiate(sMinoPrefab);
        GameObject lMino = Instantiate(lMinoPrefab);
        GameObject jMino = Instantiate(jMinoPrefab);
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
    void Type4(char direction, float high) {
        //
        //
        //
        //
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject lMino = Instantiate(lMinoPrefab);
        GameObject jMino = Instantiate(jMinoPrefab);
        GameObject zMino = Instantiate(zMinoPrefab);
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
    void Type5(char direction, float high) {
        //
        //
        //
        //
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject lMino1 = Instantiate(lMinoPrefab);
        GameObject lMino2 = Instantiate(lMinoPrefab);
        GameObject oMino = Instantiate(oMinoPrefab);
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
    void Type6(char direction, float high) {
        //
        //
        //
        //
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject jMino1 = Instantiate(jMinoPrefab);
        GameObject jMino2 = Instantiate(jMinoPrefab);
        GameObject oMino = Instantiate(oMinoPrefab);
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
    void Type7(char direction, float high) {
        //
        //
        //
        //
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject jMino = Instantiate(jMinoPrefab);
        GameObject tMino1 = Instantiate(tMinoPrefab);
        GameObject tMino2 = Instantiate(tMinoPrefab);
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
    void Type8(char direction, float high) {
        //
        //
        //
        //
        GameObject iMino = Instantiate(iMinoPrefab);
        GameObject lMino = Instantiate(lMinoPrefab);
        GameObject tMino1 = Instantiate(tMinoPrefab);
        GameObject tMino2 = Instantiate(tMinoPrefab);
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
    void Type9(char direction, float high) {
        /*
        //
        //
        //
        //
        GameObject ;
        GameObject ;
        GameObject ;
        GameObject ;
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
    void Type10(char direction, float high) {
        /*
        //
        //
        //
        //
        GameObject ;
        GameObject ;
        GameObject ;
        GameObject ;
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
    void Type11(char direction, float high) {
        /*
        //
        //
        //
        //
        GameObject ;
        GameObject ;
        GameObject ;
        GameObject ;
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
    void Type12(char direction, float high) {
        /*
        //
        //
        //
        //
        GameObject ;
        GameObject ;
        GameObject ;
        GameObject ;
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
    void Type13(char direction, float high) {
        /*
        //
        //
        //
        //
        GameObject ;
        GameObject ;
        GameObject ;
        GameObject ;
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

    // Update is called once per frame
    void Update() {

    }
}
