using UnityEngine; 
using TMPro;
using System.Collections; 
public class FirstGameCountdown : MonoBehaviour
{
    // UI�ɕ\������e�L�X�g�p�̕ϐ�
    public TextMeshProUGUI countdownText; // TextMeshPro���g�p����ꍇ�͂����Œ�`

    // �J�E���g�_�E���̏������Ԃ�ݒ�
    private float countdownTime = 3.0f;

    // �X�^�[�g���\�b�h - �Q�[���I�u�W�F�N�g���L���ɂȂ����Ƃ��ɍŏ��ɌĂ΂�܂�
    void Start()
    {
        // �J�E���g�_�E���̃R���[�`�����J�n
        StartCoroutine(CountdownRoutine());
    }

    // �J�E���g�_�E�����s���R���[�`��
    private IEnumerator CountdownRoutine()
    {
        // countdownTime��0���傫���ԁA�J�E���g�_�E���𑱂���
        while (countdownTime > 0)
        {
            // ���݂̃J�E���g�_�E���̒l���e�L�X�g�ɕ\��
            countdownText.text = countdownTime.ToString("0");

            // 1�b�҂i���̃��[�v�܂ł̒x���j
            yield return new WaitForSeconds(1f);

            // �J�E���g�_�E���̒l��1���炷
            countdownTime--;
        }

        // �J�E���g�_�E�����I��������uStart!�v�ƕ\��
        countdownText.text = "Start";

        // 1�b�҂i�uStart!�v��\�����Ă���ԁj
        yield return new WaitForSeconds(1f);

        GameManager.Instance.isGameActive = true;
        // �ēx�e�L�X�g���\���ɂ���
        countdownText.gameObject.SetActive(false);
    }
}