using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MonoBehaviour {
    private int s = 0;
    private Text u;

    void Start() {
        GameObject cO = new GameObject("C");
        Canvas canvas = cO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        cO.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        cO.AddComponent<GraphicRaycaster>();

        GameObject bO = new GameObject("B");
        bO.transform.SetParent(cO.transform, false);
        bO.AddComponent<CanvasRenderer>();
        bO.AddComponent<Image>().rectTransform.sizeDelta = new Vector2(400, 400);
        bO.AddComponent<Button>().onClick.AddListener(() => {
            s++;
            if (u != null) u.text = "S:" + s;
        });

        GameObject tO = new GameObject("T");
        tO.transform.SetParent(cO.transform, false);
        tO.AddComponent<CanvasRenderer>();
        
        u = tO.AddComponent<Text>();
        
        u.font = Font.CreateDynamicFontFromOSFont("Arial", 80); 
        
        u.fontSize = 80;
        u.alignment = TextAnchor.MiddleCenter;
        u.color = Color.white;
        u.text = "S:0";
        u.rectTransform.sizeDelta = new Vector2(600, 200);
        u.rectTransform.localPosition = new Vector3(0, 300, 0);
    }
}
