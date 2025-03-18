using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive = false; // �Q�[�����A�N�e�B�u���ǂ����̏�Ԃ��Ǘ�

    private ScoreManager scoreManager;
    private HighScoreManager highScoreManager;

    void Awake()
    {
        // �V���O���g���p�^�[���̐ݒ�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManagers(); // �}�l�[�W���[�̏�����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeManagers()
    {
        scoreManager = ScoreManager.Instance; // ScoreManager�̃C���X�^���X���擾
        highScoreManager = HighScoreManager.Instance; // HighScoreManager�̃C���X�^���X���擾
    }

    public void StartGame()
    {
        isGameActive = true;
        scoreManager.ResetScore(); // �Q�[���J�n���ɃX�R�A�����Z�b�g
        // ���̑��A�Q�[���J�n���ɕK�v�ȏ������������s��
    }

    public void EndGame()
    {
        isGameActive = false;
        int finalScore = scoreManager.GetScore(); // ���݂̃X�R�A���擾
        highScoreManager.TryAddScore(finalScore); // �n�C�X�R�A�ɒǉ�
        // ���̑��A�Q�[���I�����ɕK�v�ȏ������s��
    }
}