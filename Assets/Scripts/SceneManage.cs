using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void StartButtom()
    {
        SceneManager.LoadScene("GameScene"); //ゲームシーンにかわる
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay1");//遊び方シーン１にかわる
    }

    public void HowToPlay2()
    {
        SceneManager.LoadScene("HowToPlay2");//遊び方シーン２にかわる
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
