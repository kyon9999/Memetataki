using UnityEngine;
using UnityEngine.UI;

public class MaskControl : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RectMask2D rectMask;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rectMask = GetComponentInParent<RectMask2D>(); // RectMask2Dコンポーネントを取得
    }

    private void Update()
    {
        // RectMask2D内にいるか確認する
        if (IsInsideMask())
        {
            // BoxColliderを有効にする
            boxCollider.enabled = true; // コライダーを有効にする
        }
        else
        {
            // BoxColliderを無効にする
            boxCollider.enabled = false; // コライダーを無効にする
        }
    }

    private bool IsInsideMask()
    {
        // オブジェクトの位置を取得
        Vector3 objectPosition = transform.position;

        // RectMask2Dの位置を考慮して、オブジェクトのローカル座標を取得
        Vector2 localPosition = rectMask.transform.InverseTransformPoint(objectPosition);

        // RectMask2Dの範囲を取得
        Rect maskRect = rectMask.rectTransform.rect;

        // ローカル座標がRectMask2Dの範囲内かをチェック
        return maskRect.Contains(localPosition);
    }
}