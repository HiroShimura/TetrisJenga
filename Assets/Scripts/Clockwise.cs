﻿using UnityEngine;

public class Clockwise : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, 0, -0.1f);
    }
}
