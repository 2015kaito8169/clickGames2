using UnityEngine;
using UnityEngine.UI;
public class ClickGame : MonoBehaviour {
    private int s = 0;
    private Text t;
    void Start() {
        GameObject c = new GameObject("C");
        c.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        c.gameObject.AddComponent<GraphicRaycaster>();
        GameObject b = new GameObject("B");
        b.transform.SetParent(c.transform);
        b.AddComponent<Button>().onClick.AddListener(() => { s++; t.text = "SCORE: " + s; });
        b.AddComponent<Image>().rectTransform.sizeDelta = new Vector2(500, 500);
        GameObject tO = new GameObject("T");
        tO.transform.SetParent(c.transform);
        t = tO.AddComponent<Text>();
        t.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        t.fontSize = 100;
        t.alignment = TextAnchor.MiddleCenter;
        t.text = "SCORE: 0";
    }
}
