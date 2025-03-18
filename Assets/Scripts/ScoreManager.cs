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
            DontDestroyOnLoad(gameObject); // シーン間でオブジェクトを保持
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

    public int GetScore() // 現在のスコアを取得
    {
        return score;
    }

    public void ResetScore() // スコアをリセットするメソッド
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString("F0") + "てん";
        }
    }
}