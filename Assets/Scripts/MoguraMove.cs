using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
    private void Update()
    {
        StartRandomAnimation();
    }
    public void StartRandomAnimation()
    {

        if (animator != null)
        {
            int randomIndex = Random.Range(0, 3);//ランダムに数字をintに割り当てる
            animator.SetInteger("MemeMoveRandmIndex", randomIndex);//SetInteger呼び出し
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hummer"))
        {
            TakeDamage();
            //AttackedDamege呼び出し
            AttackedDamege();
            animator.SetTrigger("MemeReturn");
            UpdateSprite();
        }
    }

    public void TakeDamage()
    {
        ScoreManager.Instance.AddScore(1);

        // 次のアニメーションを開始するためのトリガーを設定
        animator.SetTrigger("MemeChangeDamegeAnimation");

        // 2秒遅延してUpdateSpriteを呼び出す
        Invoke("UpdateSprite", 2f);
    }

    public void AttackedDamege()
    {
        if (animator != null)
        {
            int randomIndex = Random.Range(0, 5);//ランダムに数字をintに割り当てる
            animator.SetInteger("MemeAttackedRandamIndex", randomIndex);//SetInteger呼び出し
        }
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

      


    
