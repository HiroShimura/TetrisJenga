using System.Collections;
using UnityEngine;

public class TitleSceneMinoController : MonoBehaviour {
    public GameObject tMinoPrefab;
    public GameObject iMinoPrefab;
    public GameObject oMinoPrefab;
    public GameObject sMinoPrefab;
    public GameObject zMinoPrefab;
    public GameObject jMinoPrefab;
    public GameObject lMinoPrefab;

    void Start() {
        StartCoroutine(TitleSceneCoroutine());
    }

    IEnumerator TitleSceneCoroutine() {
        float fallPosX = Random.Range(-4.5f, 4.5f);
        float fallPosY = Random.Range(3f, 5f);
        float fallPosZ = Random.Range(-9.5f, -3f);
        Instantiate(lMinoPrefab, new Vector3(0, 0, -3f), Quaternion.identity);
        yield return new WaitForSeconds(1);
        // /*
        while (true) {
            for (int i = 0; i < 10; i++) {
                GameObject selectedPrefab = prefabs[Random.Range(0, 7)];
                float fallPosX = Random.Range(-4.5f, 4.5f);
                float fallPosY = Random.Range(3f, 5f);
                float fallPosZ = Random.Range(-9.3f, -3f);
                Instantiate(selectedPrefab, new Vector3(fallPosX, fallPosY, fallPosZ), Quaternion.identity);
            }
            float sec = Random.Range(1f, 3f);
            yield return new WaitForSeconds(sec);
        }
        */
    }
}
