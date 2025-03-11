using UnityEngine;
using TMPro;


public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;

    [SerializeField] private float _MaxTime = 30;




    void Update()
    {

        if (!GameManager.Instance.isGameActive)
        {
            return; // �Q�[������A�N�e�B�u�ȏꍇ�A�����𒆒f
        }
        _MaxTime -= Time.deltaTime;//���Ԃ��J�E���g�_�E������

        TimerText.text = "�̂��肶����" + _MaxTime.ToString("F1") + "�т傤";//���Ԃ�\��

        if (_MaxTime < 0)
        {
            TimerText.text = "���ԂɂȂ�܂���";
           
        }

    }
}
