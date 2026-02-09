using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MonoBehaviour {
    private int s = 0;
    private Text t;

    void Start() {
        GameObject cO = new GameObject("C");
        Canvas c = cO.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        cO.AddComponent<CanvasScaler>();
        cO.AddComponent<GraphicRaycaster>();

        GameObject bO = new GameObject("B");
        bO.transform.SetParent(cO.transform);
        Button b = bO.AddComponent<Button>();
        Image i = bO.AddComponent<Image>();
        i.rectTransform.sizeDelta = new Vector2(400, 400);
        i.rectTransform.localPosition = Vector3.zero;

        GameObject tO = new GameObject("T");
        tO.transform.SetParent(cO.transform);
        t = tO.AddComponent<Text>();
        t.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        t.fontSize = 80;
        t.alignment = TextAnchor.MiddleCenter;
        t.rectTransform.localPosition = new Vector3(0, 300, 0);
        t.color = Color.white;
        t.text = "SCORE: 0";

        b.onClick.AddListener(() => {
            s++;
            t.text = "SCORE: " + s;
        });
    }
}

