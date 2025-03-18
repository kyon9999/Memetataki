using UnityEngine;
using TMPro; // TextMeshPro���g�p����ꍇ

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // �V���O���g���C���X�^���X

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText; // �X�R�A�\���p

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[���ԂŃI�u�W�F�N�g��ێ�
        }
        else
        {
            Destroy(gameObject); // �V���O���g�����ێ�
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public int GetScore() // ���݂̃X�R�A���擾
    {
        return score;
    }

    public void ResetScore() // �X�R�A�����Z�b�g���郁�\�b�h
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString("F0") + "�Ă�";
        }
    }
}