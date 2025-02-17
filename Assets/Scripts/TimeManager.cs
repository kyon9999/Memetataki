using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI timerTexit;

  [SerializeField]  private float _MaxTime = 30;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _MaxTime -= Time.deltaTime;//���Ԃ��J�E���g�_�E������

        timerTexit.text = "�̂��肶����"+_MaxTime.ToString("F1") + "�т傤";//���Ԃ�\��

        if (_MaxTime < 0 )
        {
            timerTexit.text = "���ԂɂȂ�܂���";//�����Ɏ��ԏI����̋@�\������
        }
    }
}
