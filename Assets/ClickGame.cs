using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickGame : MonoBehaviour {
    [Header("UI Elements")]
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
    private AudioSource audioSource;

    void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        savedScore = PlayerPrefs.GetInt("ultra_click_score", 0);
        highScoreText.text = savedScore.ToString();
        
        retryButton.gameObject.SetActive(false);
        mainButton.onClick.AddListener(OnClickButton);
        retryButton.onClick.AddListener(ResetGame);
        
        msgText.text = "";
        rankText.text = "";
    }

    void OnClickButton() {
        if (timeLeft <= 0) return;

        PlayTone(440 + score * 2, 0.1f);

        if (!active) {
            active = true;
            mainButton.GetComponentInChildren<Text>().text = "HIT!!";
            StartCoroutine(StartTimer());
            StartCoroutine(BGMTask());
        }

        score++;
        scoreText.text = score.ToString();
    }

    
    IEnumerator StartTimer() {
        while (timeLeft > 0) {
            yield return new WaitForSeconds(1f);
            timeLeft--;
            timeText.text = timeLeft.ToString();
        }
        FinishGame();
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

    void FinishGame() {
        active = false;
        mainButton.interactable = false;
        mainButton.GetComponentInChildren<Text>().text = "FINISH";

        if (score > savedScore) {
            PlayerPrefs.SetInt("ultra_click_score", score);
            highScoreText.text = score.ToString();
            msgText.text = "🔥 NEW RECORD! 🔥";
            StartCoroutine(Fanfare());
        } else {
            PlayTone(150f, 0.5f, 0.1f);
        }

        rankText.text = GetRank(score);
        retryButton.gameObject.SetActive(true);
    }

    IEnumerator Fanfare() {
        float[] f = { 523f, 659f, 783f };
        foreach (float n in f) {
            PlayTone(n, 0.4f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    string GetRank(int s) {
        if (s >= 1000) return "fraud        if (s >= 250) return         if (s >= 250) return (これ絶対あなた不正したでしょ神より上になることまずないし10秒だよふつう1000回より上に行けるか?)";
　　　　 if (s >= 250) return "fraud (不正)";
        if (s >= 200) return "GOD (神)"; 
        if (s >= 150) return "LEGEND (伝説)";
        if (s >= 100) return "PRO (超人)";
        if (s >= 80)  return "semi-pro (上級者)";
        if (s >= 50)  return "Amateur (中級者)";
        return "NOOB (初心者)";
    }

    void PlayTone(float freq, float duration, float volume = 0.1f) {
        GameObject tone = new GameObject("Tone");
        AudioSource source = tone.AddComponent<AudioSource>();
        int samplerate = 44100;
        AudioClip clip = AudioClip.Create("Tone", (int)(samplerate * duration), 1, samplerate, false);
        float[] data = new float[clip.samples];
        for (int i = 0; i < data.Length; i++) {
            data[i] = Mathf.Sin(2 * Mathf.PI * freq * i / samplerate) * volume;
        }
        clip.SetData(data, 0);
        source.PlayOneShot(clip);
        Destroy(tone, duration + 0.1f);
    }

    void ResetGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
