
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive = false; // ゲームがアクティブかどうかの状態を管理

    void Awake()
    {
        // シングルトンパターンの設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartButtom()
    {
        SceneManager.LoadScene("GameScene"); //ゲームシーンにかわる
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");//遊び方シーンにかわる
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");//設定シーンにかわる
    }

    public void ReturnStartMenu()
    {
        SceneManager.LoadScene("StartScene");//スタートシーンにかわる
    }

    public void ResultMenu()
    {
        SceneManager.LoadScene("ResultScene");//リザルトシーンにかわる
    }
}

