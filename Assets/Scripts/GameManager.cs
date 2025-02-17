
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}

