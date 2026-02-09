using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unityroom.Api;

public class ClickGame : MonoBehaviour {
    public Text scoreText;
    public Text timeText;
    public Text highScoreText;
    public Text rankText;
    public Text msgText;
    public Button mainButton;
    public Button retryButton;

    private int score = 0;
    private float timeLeft = 10f;
    private bool active = false;
    private int savedScore;

    void Start() {
        // ここでAPIキーを無理やりセット（設定画面をいじらなくて済む方法）
        UnityroomApiClient.Instance.Initialize("MbDTMCsbd6UwYqzTOEARbyMFK2CU5j38F0IA4KRO1G7y+Tz+cQr2MHmOoONyaSfA5V71vCg3iFj74qXbCBEVzw==");
        
        savedScore = PlayerPrefs.GetInt("ultra_click_score", 0);
        if(highScoreText) highScoreText.text = savedScore.ToString();
        if(retryButton) retryButton.gameObject.SetActive(false);
        if(mainButton) mainButton.onClick.AddListener(OnClickButton);
        if(retryButton) retryButton.onClick.AddListener(ResetGame);
    }

    void OnClickButton() {
        if (timeLeft <= 0) return;
        PlayTone(440 + score * 2, 0.1f);
        if (!active) {
            active = true;
            Text btnText = mainButton.GetComponentInChildren<Text>();
            if(btnText) btnText.text = "HIT!!";
            StartCoroutine(StartTimer());
            StartCoroutine(BGMTask());
        }
        score++;
        if(scoreText) scoreText.text = score.ToString();
    }

    IEnumerator StartTimer() {
        while (timeLeft > 0) {
            yield return new WaitForSeconds(1f);
            timeLeft--;
            if(timeText) timeText.text = timeLeft.ToString();
        }
        FinishGame();
    }

    void FinishGame() {
        active = false;
        mainButton.interactable = false;
        if(score > savedScore) {
            PlayerPrefs.SetInt("ultra_click_score", score);
            if(highScoreText) highScoreText.text = score.ToString();
            msgText.text = "NEW RECORD!";
            StartCoroutine(Fanfare());
            
            // ボードNo.1へ送信。unityroom側で「ボード1」が作られていれば届きます
            UnityroomApiClient.Instance.SendScore(1, (float)score, ScoreOrder.OrderByDescending);
        } else {
            PlayTone(150f, 0.5f, 0.1f);
        }
        rankText.text = GetRank(score);
        retryButton.gameObject.SetActive(true);
    }

    IEnumerator BGMTask() {
        float[] notes = { 110f, 130f, 110f, 146f };
        int step = 0;
        while (active) {
            PlayTone(notes[step % notes.length], 0.2f, 0.05f);
            step++;
            yield return new WaitForSeconds(0.25f);
        }
    }

    IEnumerator Fanfare() {
        float[] f = { 523f, 659f, 783f };
        foreach (float n in f) {
            PlayTone(n, 0.4f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    string GetRank(int s) {
        if (s >= 250) return "FRAUD";
        if (s >= 200) return "GOD";
        if (s >= 150) return "LEGEND";
        if (s >= 100) return "PRO";
        if (s >= 80) return "SEMI-PRO";
        if (s >= 50) return "AMATEUR";
        return "NOOB";
    }

    void PlayTone(float f, float d, float v = 0.1f) {
        GameObject t = new GameObject("T");
        AudioSource s = t.AddComponent<AudioSource>();
        AudioClip c = AudioClip.Create("T", (int)(44100 * d), 1, 44100, false);
        float[] dat = new float[c.samples];
        for (int i = 0; i < dat.Length; i++) dat[i] = Mathf.Sin(2 * Mathf.PI * f * i / 44100) * v;
        c.SetData(dat, 0);
        s.PlayOneShot(c);
        Destroy(t, d + 0.1f);
    }

    void ResetGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
