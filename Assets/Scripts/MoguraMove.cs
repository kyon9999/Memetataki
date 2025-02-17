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
            int randomIndex = Random.Range(0, 3);//�����_���ɐ�����int�Ɋ��蓖�Ă�
            animator.SetInteger("MemeMoveRandmIndex", randomIndex);//SetInteger�Ăяo��
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hummer"))
        {
            TakeDamage();
            //AttackedDamege�Ăяo��
            AttackedDamege();
            animator.SetTrigger("MemeReturn");
            UpdateSprite();
        }
    }

    public void TakeDamage()
    {
        ScoreManager.Instance.AddScore(1);

        // ���̃A�j���[�V�������J�n���邽�߂̃g���K�[��ݒ�
        animator.SetTrigger("MemeChangeDamegeAnimation");

        // 2�b�x������UpdateSprite���Ăяo��
        Invoke("UpdateSprite", 2f);
    }

    public void AttackedDamege()
    {
        if (animator != null)
        {
            int randomIndex = Random.Range(0, 5);//�����_���ɐ�����int�Ɋ��蓖�Ă�
            animator.SetInteger("MemeAttackedRandamIndex", randomIndex);//SetInteger�Ăяo��
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

      


    
