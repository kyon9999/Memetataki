using UnityEngine;
using TMPro; // TextMeshProを使用する場合

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // シングルトンインスタンス

    private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText; // スコア表示用

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // シングルトンを維持
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString("F0")+"てん";
        }
    }
}