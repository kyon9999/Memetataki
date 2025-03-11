using UnityEngine; 
using TMPro;
using System.Collections; 
public class FirstGameCountdown : MonoBehaviour
{
    // UIに表示するテキスト用の変数
    public TextMeshProUGUI countdownText; // TextMeshProを使用する場合はここで定義

    // カウントダウンの初期時間を設定
    private float countdownTime = 3.0f;

    // スタートメソッド - ゲームオブジェクトが有効になったときに最初に呼ばれます
    void Start()
    {
        // カウントダウンのコルーチンを開始
        StartCoroutine(CountdownRoutine());
    }

    // カウントダウンを行うコルーチン
    private IEnumerator CountdownRoutine()
    {
        // countdownTimeが0より大きい間、カウントダウンを続ける
        while (countdownTime > 0)
        {
            // 現在のカウントダウンの値をテキストに表示
            countdownText.text = countdownTime.ToString("0");

            // 1秒待つ（次のループまでの遅延）
            yield return new WaitForSeconds(1f);

            // カウントダウンの値を1減らす
            countdownTime--;
        }

        // カウントダウンが終了したら「Start!」と表示
        countdownText.text = "Start";

        // 1秒待つ（「Start!」を表示している間）
        yield return new WaitForSeconds(1f);

        GameManager.Instance.isGameActive = true;
        // 再度テキストを非表示にする
        countdownText.gameObject.SetActive(false);
    }
}