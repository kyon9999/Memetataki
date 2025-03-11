
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive = false; // �Q�[�����A�N�e�B�u���ǂ����̏�Ԃ��Ǘ�

    void Awake()
    {
        // �V���O���g���p�^�[���̐ݒ�
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
        SceneManager.LoadScene("GameScene"); //�Q�[���V�[���ɂ����
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");//�V�ѕ��V�[���ɂ����
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");//�ݒ�V�[���ɂ����
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

