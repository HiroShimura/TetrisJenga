using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    [field: SerializeField, Range(4, 12)]
    public int Layers { get; set; }

    List<GameObject> minos;
    // Start is called before the first frame update
    void Start() {
        minos = new List<GameObject>();
        for (int layer = 1; layer < Layers + 1; layer++) {
            for (int num = 1; num < 5; num++) {
                GameObject mino = GameObject.Find($"{layer}_{num}");
                minos.Add(mino);
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
