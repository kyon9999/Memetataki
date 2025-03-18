using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void GoGameScene()
    {
      FadeManager.Instance.LoadScene("GameScene",1f); //ゲームシーンにかわる
    }

    public void HowToPlay()
    {
        FadeManager.Instance.LoadScene("HowToPlay1",1f);//遊び方シーン１にかわる
    }

    public void HowToPlay2()
    {
        FadeManager.Instance.LoadScene("HowToPlay2", 1f);//遊び方シーン２にかわる
    }

    public void ReturnStartMenu()
    {
        FadeManager.Instance.LoadScene("StartScene", 1f);//スタートシーンにかわる
    }

    public void ResultMenu()
    {
        FadeManager.Instance.LoadScene("ResultScene", 1f);//リザルトシーンにかわる
    }
}
