using UnityEngine;

public class Memo : MonoBehaviour {

    /*
     * ミノを積んだ後の次のプレイヤーへの入れ替えにはコルーチンを使う（3～4秒くらい？）
     * 
     * ミノの高さを調べる方法を用意し、ミノを積む際のカメラ移動とペナルティーで利用
     * 
     * ミノがTableの外側に落ちるかTableに触れたらGameOver
     * 下のミノからRigidbodyを無効化&灰色マテリアルを適用（できれば下方向からのグラデーション付き）でTETRIS99みたいなミノが灰色になるアニメーションを再現可能か？
     * GameOverの時点でCameraControllerやMinoCatcherを無効化するのを忘れずに
     */

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
