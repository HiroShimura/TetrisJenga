using System.Collections;
using UnityEngine;

public class TitleSceneMinoController : MonoBehaviour {
    [SerializeField] GameObject[] prefabs;
    Vector3 rotate;

    void Awake() {
        StartCoroutine(TitleSceneCoroutine());
    }

    IEnumerator TitleSceneCoroutine() {
        while (true) {
            int posZ = Random.Range(0, 6);
            rotate = new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));
            switch (posZ) {
                case 0:
                    Instantiate(prefabs[Random.Range(0, 7)], new Vector3(Random.Range(-10f, 10f), 14, 0), Quaternion.Euler(rotate));
                    break;
                case 1:
                    Instantiate(prefabs[Random.Range(0, 7)], new Vector3(Random.Range(-8.5f, 8.5f), 12, -1.5f), Quaternion.Euler(rotate));
                    break;
                case 2:
                    Instantiate(prefabs[Random.Range(0, 7)], new Vector3(Random.Range(-6.5f, 6.5f), 10, -3.5f), Quaternion.Euler(rotate));
                    break;
                case 3:
                    Instantiate(prefabs[Random.Range(0, 7)], new Vector3(Random.Range(-4.5f, 4.5f), 8, -5.5f), Quaternion.Euler(rotate));
                    break;
                case 4:
                    Instantiate(prefabs[Random.Range(0, 7)], new Vector3(Random.Range(-2.5f, 2.5f), 6, -7.5f), Quaternion.Euler(rotate));
                    break;
                case 5:
                    Instantiate(prefabs[Random.Range(0, 7)], new Vector3(Random.Range(-0.5f, 0.5f), 4, -9.5f), Quaternion.Euler(rotate));
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        }
        /*
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
