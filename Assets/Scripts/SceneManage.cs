using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void GoGameScene()
    {
      FadeManager.Instance.LoadScene("GameScene",1f); //�Q�[���V�[���ɂ����
    }

    public void HowToPlay()
    {
        FadeManager.Instance.LoadScene("HowToPlay1",1f);//�V�ѕ��V�[���P�ɂ����
    }

    public void HowToPlay2()
    {
        FadeManager.Instance.LoadScene("HowToPlay2", 1f);//�V�ѕ��V�[���Q�ɂ����
    }

    public void ReturnStartMenu()
    {
        FadeManager.Instance.LoadScene("StartScene", 1f);//�X�^�[�g�V�[���ɂ����
    }

    public void ResultMenu()
    {
        FadeManager.Instance.LoadScene("ResultScene", 1f);//���U���g�V�[���ɂ����
    }
}
