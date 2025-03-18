using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance; // �V���O���g���C���X�^���X

    private List<int> highScores = new List<int>(); // �n�C�X�R�A�̃��X�g
    [SerializeField] private TextMeshProUGUI[] highScoresTexts; // �n�C�X�R�A��\�����邽�߂̃e�L�X�g�z��

    private const string HighScoreKey = "HighScores"; // PlayerPrefs�̃L�[��

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[���ԂŃI�u�W�F�N�g��ێ�
            LoadHighScores(); // �n�C�X�R�A�����[�h
        }
        else
        {
            Destroy(gameObject); // �d������C���X�^���X���폜
        }

        InitializeHighScores(); // �n�C�X�R�A�̏�����
        UpdateHighScoresText(); // ��ʂ̃n�C�X�R�A�\�����X�V
    }

    private void InitializeHighScores()
    {
        if (highScores.Count == 0) // �܂��n�C�X�R�A���ݒ肳��Ă��Ȃ��ꍇ
        {
            for (int i = 0; i < 4; i++)
            {
                highScores.Add(0); // �n�C�X�R�A��6��0�ŏ�����
            }
        }
    }

    public void TryAddScore(int score)
    {
        highScores.Add(score); // �V�����X�R�A��ǉ�
        highScores.Sort((a, b) => b.CompareTo(a)); // �X�R�A���~���Ń\�[�g
        if (highScores.Count > 4)
        {
            highScores.RemoveAt(4); // ���6�̃X�R�A�̂ݕێ�
        }
        SaveHighScores(); // �n�C�X�R�A��ۑ�
        UpdateHighScoresText(); // �n�C�X�R�A�e�L�X�g�̍X�V
    }

    private void LoadHighScores() // �n�C�X�R�A�����[�h���郁�\�b�h
    {
        string highScoresString = PlayerPrefs.GetString(HighScoreKey, string.Empty);
        if (!string.IsNullOrEmpty(highScoresString))
        {
            string[] scoreStrings = highScoresString.Split(',');
            foreach (string score in scoreStrings)
            {
                if (int.TryParse(score, out int parsedScore))
                {
                    highScores.Add(parsedScore);
                }
            }
        }
    }

    private void SaveHighScores() // �n�C�X�R�A��ۑ����郁�\�b�h
    {
        // �X�R�A���R���}��؂�̕�����ɕϊ�
        PlayerPrefs.SetString(HighScoreKey, string.Join(",", highScores));
        PlayerPrefs.Save(); // PlayerPrefs��ۑ�
    }

    private void UpdateHighScoresText()
    {
        for (int i = 0; i < highScoresTexts.Length; i++)
        {
            if (i < highScores.Count) // �G���[��h�����߂ɁA�C���f�b�N�X���n�C�X�R�A���X�g�͈͓̔����m�F
            {
                highScoresTexts[i].text = $"{i + 1}: {highScores[i]} �Ă�";
            }
            else
            {
                highScoresTexts[i].text = $"{i + 1}: 0 �Ă�"; // �X�R�A���Ȃ��ꍇ��0�ŕ\��
            }
        }
    }
}