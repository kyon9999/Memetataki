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
            return; // ゲームが非アクティブな場合、処理を中断
        }
        _MaxTime -= Time.deltaTime;//時間をカウントダウンする

        TimerText.text = "のこりじかん" + _MaxTime.ToString("F1") + "びょう";//時間を表示

        if (_MaxTime < 0)
        {
            TimerText.text = "時間になりました";
           
        }

    }
}
