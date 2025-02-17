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

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString("F0")+"�Ă�";
        }
    }
}