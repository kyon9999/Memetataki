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
            return; // ゲームが非アクティブな場合、処理を中断
        }

        _MaxTime -= Time.deltaTime; // 時間をカウントダウンする

        // _MaxTimeが0未満になるのを防ぐ
        if (_MaxTime < 0)
        {
            _MaxTime = 0;
        }

        TimerText.text = "のこりじかん" + _MaxTime.ToString("F1") + "びょう"; // 時間を表示

        // 時間が0になり、オーディオが再生されていない場合
        if (_MaxTime == 0 && !hasPlayAudio)
        {
            TimerText.text = "時間になりました"; // メッセージを表示
            _AudioSource.Play(); // オーディオを再生
            hasPlayAudio = true; // フラグを設定

            StartCoroutine(WaitPlayAudio()); // コルーチンを開始
        }
    }

    private IEnumerator WaitPlayAudio()
    {
        yield return new WaitForSeconds(2.0f); // 2秒待機
        FadeManager.Instance.LoadScene("ResultScene", 1f); // シーンをロード
    }
}