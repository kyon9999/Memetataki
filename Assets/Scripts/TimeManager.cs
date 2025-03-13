using UnityEngine;
using TMPro;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] private float _MaxTime = 30;
    [SerializeField] private AudioSource _AudioSource;

    private bool hasPlayAudio = false;

    void Update()
    {
        if (!GameManager.Instance.isGameActive)
        {
            return; // �Q�[������A�N�e�B�u�ȏꍇ�A�����𒆒f
        }

        _MaxTime -= Time.deltaTime; // ���Ԃ��J�E���g�_�E������

        // _MaxTime��0�����ɂȂ�̂�h��
        if (_MaxTime < 0)
        {
            _MaxTime = 0;
        }

        TimerText.text = "�̂��肶����" + _MaxTime.ToString("F1") + "�т傤"; // ���Ԃ�\��

        // ���Ԃ�0�ɂȂ�A�I�[�f�B�I���Đ�����Ă��Ȃ��ꍇ
        if (_MaxTime == 0 && !hasPlayAudio)
        {
            TimerText.text = "���ԂɂȂ�܂���"; // ���b�Z�[�W��\��
            _AudioSource.Play(); // �I�[�f�B�I���Đ�
            hasPlayAudio = true; // �t���O��ݒ�

            StartCoroutine(WaitPlayAudio()); // �R���[�`�����J�n
        }
    }

    private IEnumerator WaitPlayAudio()
    {
        yield return new WaitForSeconds(2.0f); // 2�b�ҋ@
        FadeManager.Instance.LoadScene("ResultScene", 1f); // �V�[�������[�h
    }
}