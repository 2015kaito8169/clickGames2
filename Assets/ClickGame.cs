using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MonoBehaviour {
    private int s = 0;
    private Text u;

    void Start() {
        GameObject cO = new GameObject("C");
        Canvas canvas = cO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        cO.AddComponent<CanvasScaler>(); // 画面解像度への自動対応
        cO.AddComponent<GraphicRaycaster>(); // クリック反応に必須
　
        GameObject bO = new GameObject("B");
        bO.transform.SetParent(cO.transform, false); 
        bO.AddComponent<CanvasRenderer>(); 
        
        Image i = bO.AddComponent<Image>();
        i.rectTransform.sizeDelta = new Vector2(400, 400);
        
        Button b = bO.AddComponent<Button>();
        b.onClick.AddListener(() => {
            s++;
            if (u != null) u.text = "S:" + s;
        });

       
        GameObject tO = new GameObject("T");
        tO.transform.SetParent(cO.transform, false);
        tO.AddComponent<CanvasRenderer>(); // 描画に必須
        
        u = tO.AddComponent<Text>();
   
        u.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        u.fontSize = 80;
        u.alignment = TextAnchor.MiddleCenter;
        u.color = Color.white;
        u.text = "S:0";

        u.rectTransform.sizeDelta = new Vector2(600, 200);
        u.rectTransform.localPosition = new Vector3(0, 300, 0);
    }
}
