using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive = false; // ゲームがアクティブかどうかの状態を管理

    private ScoreManager scoreManager;
    private HighScoreManager highScoreManager;

    void Awake()
    {
        // シングルトンパターンの設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManagers(); // マネージャーの初期化
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeManagers()
    {
        scoreManager = ScoreManager.Instance; // ScoreManagerのインスタンスを取得
        highScoreManager = HighScoreManager.Instance; // HighScoreManagerのインスタンスを取得
    }

    public void StartGame()
    {
        isGameActive = true;
        scoreManager.ResetScore(); // ゲーム開始時にスコアをリセット
        // その他、ゲーム開始時に必要な初期化処理を行う
    }

    public void EndGame()
    {
        isGameActive = false;
        int finalScore = scoreManager.GetScore(); // 現在のスコアを取得
        highScoreManager.TryAddScore(finalScore); // ハイスコアに追加
        // その他、ゲーム終了時に必要な処理を行う
    }
}