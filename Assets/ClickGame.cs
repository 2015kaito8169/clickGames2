using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MonoBehaviour {
    private int s = 0;
    private int h = 0;
    private float t = 10f;
    private bool a = false;
    private Text u; // ←ここ！名前「u」の後にセミコロン！

    void Start() {
        h = PlayerPrefs.GetInt("H", 0);
       GameObject b = new GameObject("B");
        b.transform.SetParent(c.transform);
        b.AddComponent<Button>().onClick.AddListener(() => {
            s++;
            if(t != null) t.text = "S:" + s;
        });
        b.AddComponent<Image>().rectTransform.sizeDelta = new Vector2(400, 400);

        GameObject o = new GameObject("T");
        o.transform.SetParent(c.transform);
        t = o.AddComponent<Text>();
        t.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        t.fontSize = 80;
        t.alignment = TextAnchor.MiddleCenter;
        t.color = Color.white;
        t.text = "S:0";
    }
}
