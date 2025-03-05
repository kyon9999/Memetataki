using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Mole : MonoBehaviour
{
    private Animator animator;
    private Collider2D moleCollider;
    private Image imageComponent;
    public List<AnimationClip> damageAnimations;
    public List<Sprite> moleSprites;

    void Start()
    {
        animator = GetComponent<Animator>();
        moleCollider = GetComponent<Collider2D>();
        imageComponent = GetComponent<Image>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hummer"))
        {
            // ステート1からステート2への遷移
            animator.SetBool("MemeReturn", true);
            Debug.Log("MemeReturnをtrueに設定");

            // ダメージ処理を呼ぶ
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        ScoreManager.Instance.AddScore(1);

        animator.SetTrigger("MemeFreeze"); // ステート2からステート3への遷移
        // 2秒遅延してUpdateSpriteを呼び出す
        Invoke("UpdateSprite", 2f);
        StartCoroutine(ResetMemeReturn());
    }

    private IEnumerator ResetMemeReturn()
    {
        // 3つ目のアニメーションが終わったことを待つ
        yield return new WaitForSeconds(2f); // 適切な時間に調整
        animator.SetBool("MemeReturn", false); // ステート3からステート4への遷移
        Debug.Log("MemeReturnをfalseに設定");
    }

    private void UpdateSprite()
    {
        if (imageComponent != null && moleSprites.Count > 0)
        {
            int randomIndex = Random.Range(0, moleSprites.Count);
            imageComponent.sprite = moleSprites[randomIndex];
        }
    }
}