using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MonoBehaviour {
    private int s = 0;
    private Text u;

    void Start() {
     GameObject cO = new GameObject("C");
        Canvas canvas = cO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        cO.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize; // 追記：解像度固定
        cO.AddComponent<GraphicRaycaster>();

        
        GameObject bO = new GameObject("B");
        bO.transform.SetParent(cO.transform, false);
        bO.AddComponent<CanvasRenderer>();
        
        Image i = bO.AddComponent<Image>();
        i.rectTransform.sizeDelta = new Vector2(400, 400);
        i.color = new Color(1, 1, 1, 0.5f); 
        
        bO.AddComponent<Button>().onClick.AddListener(() => {
            s++;
            if (u != null) u.text = "S:" + s;
        });

        GameObject tO = new GameObject("T");
        tO.transform.SetParent(cO.transform, false);
        tO.AddComponent<CanvasRenderer>();
        
        u = tO.AddComponent<Text>();
        
        u.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf"); 
        if(u.font == null) u.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");

        u.fontSize = 80;
        u.alignment = TextAnchor.MiddleCenter;
        u.color = Color.black; 
　      u.text = "S:0";
        u.rectTransform.sizeDelta = new Vector2(600, 200);
        u.rectTransform.localPosition = new Vector3(0, 300, 0);
    }
}
