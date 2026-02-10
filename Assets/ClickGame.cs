using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MonoBehaviour {
    private int s = 0;
    private Text u;

    void Start() {
        
        GameObject cO = new GameObject("C");
        Canvas canvas = cO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        cO.AddComponent<CanvasScaler>();
        cO.AddComponent<GraphicRaycaster>();


    　　 GameObject bO = new GameObject("B");
        bO.transform.SetParent(cO.transform);
        Button b = bO.AddComponent<Button>();
        b.gameObject.AddComponent<Image>().rectTransform.sizeDelta = new Vector2(400, 400);

        
        GameObject o = new GameObject("T");
        o.transform.SetParent(cO.transform); 
        t = o.AddComponent<Text>();
        t.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        t.fontSize = 80;
        t.alignment = TextAnchor.MiddleCenter;
        t.color = Color.white;
        t.text = "S:0";

        
        b.onClick.AddListener(() => {
            s++;
            if (t != null) u.text = "S:" + s;
        });
    }
}
