using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MonoBehaviour {
    private int s = 0;
    private Text t;

    void Start() {
        GameObject c = new GameObject("C");
        c.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        c.AddComponent<GraphicRaycaster>();

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
