using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI / Score")]
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    [Header("Optional Timer (Extra Points)")]
    [SerializeField] private bool useTimer = true;
    [SerializeField] private float startingTimeSeconds = 20f;
    [SerializeField] private float timeAddedPerKill = 2f;
    [SerializeField] private TMPro.TextMeshProUGUI timerText;

    private int _score;
    private float _timeLeft;

    public int Score => _score;

    private void Awake()
    {
        _timeLeft = startingTimeSeconds;
        UpdateScoreUI();
        UpdateTimerUI();
    }

    private void Update()
    {
        if (!useTimer) return;

        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0f)
        {
            ReloadScene();
            return;
        }

        UpdateTimerUI();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreUI();

        if (useTimer)
        {
            _timeLeft += timeAddedPerKill;
            UpdateTimerUI();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {_score}";
    }

    private void UpdateTimerUI()
    {
        if (!useTimer || timerText == null) return;

        float clamped = Mathf.Max(0f, _timeLeft);
        timerText.text = $"Time: {clamped:0.0}s";
    }
}
