using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MonoBehaviour {
    private int s = 0;
    private int h = 0;
    private float t = 10f;
    private bool a = false;
    private Text u;

    void Start() {
        h = PlayerPrefs.GetInt("H", 0);
        GameObject cO = new GameObject("C");
        Canvas c = cO.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        cO.AddComponent<CanvasScaler>();
        cO.AddComponent<GraphicRaycaster>();

        GameObject bO = new GameObject("B");
        bO.transform.SetParent(cO.transform);
        Button b = bO.AddComponent<Button>();
        b.gameObject.AddComponent<Image>().rectTransform.sizeDelta = new Vector2(400, 400);

        GameObject tO = new GameObject("T");
        tO.transform.SetParent(cO.transform);
        u = tO.AddComponent<Text>();
        u.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        u.fontSize = 40;
        u.alignment = TextAnchor.MiddleCenter;
        u.rectTransform.localPosition = new Vector3(0, 300, 0);
        u.color = Color.white;
        u.text = "BEST: " + h + " / TIME: 10 / SCORE: 0";

        b.onClick.AddListener(() => {
            if (t > 0) {
                a = true;
                s++;
            }
        });
    }

    void Update() {
        if (a && t > 0) {
            t -= Time.deltaTime;
            u.text = "TIME: " + Mathf.Ceil(t) + " SCORE: " + s;
            if (t <= 0) {
                string r = "NOOB";
                if (s >= 100) { r = "GOD"; }
                else if (s >= 70) { r = "PRO"; }
                else if (s >= 40) { r = "AMATEUR"; }

                if (s > h) {
                    h = s;
                    PlayerPrefs.SetInt("H", h);
                    PlayerPrefs.Save();
                }
                u.text = "RANK: " + r + " / SCORE: " + s + " / BEST: " + h;
            }
        }
    }
}
