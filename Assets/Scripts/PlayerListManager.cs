using UnityEngine;
using UnityEngine.UI;

public class PlayerListManager : MonoBehaviour {

    [SerializeField] RectTransform content;
    [SerializeField] GameObject nameListItemPrefab;
    float itemHight;
    public string[] player;

    // http://uroshika.blogspot.com/2016/02/unity-listview.html

    // Start is called before the first frame update
    void Start() {
        GameObject item = Instantiate(nameListItemPrefab);
        RectTransform rect = item.GetComponent<RectTransform>();
        itemHight = rect.rect.height;
    }

    public void UpdateListView() {
        // item数に合わせてContentの高さを変更する.
        int setting_count = player.Length;
        float newHeight = setting_count * itemHight;
        content.sizeDelta = new Vector2(content.sizeDelta.x, newHeight); // 高さを変更する.

        // Contentの子要素にListViewItemを追加していく.
        foreach (string itemStr in player) {
            GameObject item = GameObject.Instantiate(nameListItemPrefab) as GameObject; // ListViewItem のインスタンス作成.
            Text itemText = item.GetComponentInChildren<Text>(); // Textコンポーネントを取得.
            itemText.text = itemStr;

            RectTransform itemTransform = (RectTransform)item.transform;
            itemTransform.SetParent(content, false); // 作成したItemをContentの子要素に設定.
        }
    }
}
