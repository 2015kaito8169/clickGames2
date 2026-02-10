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
        co.transform.SetParent(cO.transform); 
        u. = o.AddComponent<Text>();
        u.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        u.fontSize = 80;
        u.alignment = TextAnchor.MiddleCenter;
        u.color = Color.white;
        u.text = "S:0";

        
        b.onClick.AddListener(() => {
            s++;
            if (t != null) u.text = "S:" + s;
        });
    }
}
