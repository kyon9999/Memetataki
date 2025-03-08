using UnityEngine;
using System.Collections;
public class MovingObject : MonoBehaviour
{
    public Sprite[] sprites; // 差し替え用スプライト
    public float moveSpeed = 1.0f;
    public Vector3[] movePatterns; // 上下移動のパターン
    public Vector3[] fallPatterns; // 下に落ちるパターン
    private int currentSpriteIndex = 0;
    private bool isFalling = false;
    private ScoreManager scoreManager;

    void Start()
    {
        // ランダムな移動パターンを選択
        InvokeRepeating("MoveUpAndDown", 0, 2.0f);
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void MoveUpAndDown()
    {
        if (!isFalling)
        {
            Vector3 movePattern = movePatterns[Random.Range(0, movePatterns.Length)];
            transform.position = new Vector3(transform.position.x, transform.position.y + movePattern.y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        if (!isFalling)
        {
            isFalling = true;
            CancelInvoke("MoveUpAndDown");
            StartCoroutine(FallAndChange());
        }
    }

    private IEnumerator FallAndChange()
    {
        Vector3 fallPattern = fallPatterns[Random.Range(0, fallPatterns.Length)];
        Vector3 targetPosition = transform.position + fallPattern;

        while (transform.position.y > targetPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        scoreManager.AddScore(1);

        // 画像の差し替え
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
        GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteIndex];

        isFalling = false;
        InvokeRepeating("MoveUpAndDown", 0, 2.0f);
    }
}