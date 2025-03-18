using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance; // シングルトンインスタンス

    private List<int> highScores = new List<int>(); // ハイスコアのリスト
    [SerializeField] private TextMeshProUGUI[] highScoresTexts; // ハイスコアを表示するためのテキスト配列

    private const string HighScoreKey = "HighScores"; // PlayerPrefsのキー名

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン間でオブジェクトを保持
            LoadHighScores(); // ハイスコアをロード
        }
        else
        {
            Destroy(gameObject); // 重複するインスタンスを削除
        }

        InitializeHighScores(); // ハイスコアの初期化
        UpdateHighScoresText(); // 画面のハイスコア表示を更新
    }

    private void InitializeHighScores()
    {
        if (highScores.Count == 0) // まだハイスコアが設定されていない場合
        {
            for (int i = 0; i < 4; i++)
            {
                highScores.Add(0); // ハイスコアを6つ0で初期化
            }
        }
    }

    public void TryAddScore(int score)
    {
        highScores.Add(score); // 新しいスコアを追加
        highScores.Sort((a, b) => b.CompareTo(a)); // スコアを降順でソート
        if (highScores.Count > 4)
        {
            highScores.RemoveAt(4); // 上位6つのスコアのみ保持
        }
        SaveHighScores(); // ハイスコアを保存
        UpdateHighScoresText(); // ハイスコアテキストの更新
    }

    private void LoadHighScores() // ハイスコアをロードするメソッド
    {
        string highScoresString = PlayerPrefs.GetString(HighScoreKey, string.Empty);
        if (!string.IsNullOrEmpty(highScoresString))
        {
            string[] scoreStrings = highScoresString.Split(',');
            foreach (string score in scoreStrings)
            {
                if (int.TryParse(score, out int parsedScore))
                {
                    highScores.Add(parsedScore);
                }
            }
        }
    }

    private void SaveHighScores() // ハイスコアを保存するメソッド
    {
        // スコアをコンマ区切りの文字列に変換
        PlayerPrefs.SetString(HighScoreKey, string.Join(",", highScores));
        PlayerPrefs.Save(); // PlayerPrefsを保存
    }

    private void UpdateHighScoresText()
    {
        for (int i = 0; i < highScoresTexts.Length; i++)
        {
            if (i < highScores.Count) // エラーを防ぐために、インデックスがハイスコアリストの範囲内か確認
            {
                highScoresTexts[i].text = $"{i + 1}: {highScores[i]} てん";
            }
            else
            {
                highScoresTexts[i].text = $"{i + 1}: 0 てん"; // スコアがない場合は0で表示
            }
        }
    }
}