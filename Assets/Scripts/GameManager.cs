
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
}

