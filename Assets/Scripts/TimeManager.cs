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
        _MaxTime -= Time.deltaTime;//時間をカウントダウンする

        timerTexit.text = "のこりじかん"+_MaxTime.ToString("F1") + "びょう";//時間を表示

        if (_MaxTime < 0 )
        {
            timerTexit.text = "時間になりました";//ここに時間終了後の機能をかく
        }
    }
}
