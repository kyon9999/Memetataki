using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void StartButtom()
    {
        SceneManager.LoadScene("GameScene"); //�Q�[���V�[���ɂ����
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay1");//�V�ѕ��V�[���P�ɂ����
    }

    public void HowToPlay2()
    {
        SceneManager.LoadScene("HowToPlay2");//�V�ѕ��V�[���Q�ɂ����
    }

    public void ReturnStartMenu()
    {
        SceneManager.LoadScene("StartScene");//�X�^�[�g�V�[���ɂ����
    }

    public void ResultMenu()
    {
        SceneManager.LoadScene("ResultScene");//���U���g�V�[���ɂ����
    }
}
