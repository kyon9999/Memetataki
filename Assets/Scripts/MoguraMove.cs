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
            Debug.Log("�Փ˂�������");
            // �X�e�[�g1����X�e�[�g2�ւ̑J��
            animator.SetBool("MemeReturn", true);
            Debug.Log("MemeReturn��true�ɐݒ�");

            // �_���[�W�������Ă�
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        ScoreManager.Instance.AddScore(1);

        animator.SetTrigger("MemeFreeze"); // �X�e�[�g2����X�e�[�g3�ւ̑J��
       
        StartCoroutine(ResetMemeReturn());//�񓯊������X�^�[�g
    }

    private IEnumerator ResetMemeReturn()�@//�񓯊�����
    {
        // 3�ڂ̃A�j���[�V�������I��������Ƃ�҂�
        yield return new WaitForSeconds(2f); // �K�؂Ȏ��Ԃɒ���
        UpdateSprite();
        animator.SetBool("MemeReturn", false); // �X�e�[�g3����X�e�[�g4�ւ̑J��
        Debug.Log("MemeReturn��false�ɐݒ�");
    }

    private void UpdateSprite()
    {
        if (imageComponent != null && moleSprites.Count > 0)
        {
            int randomIndex = Random.Range(0, moleSprites.Count);
            imageComponent.sprite = moleSprites[randomIndex];

            // MoleAnimatorAssigner���擾���ă��\�b�h���Ăяo��
            MoleAnimatorAssigner animatorAssigner = GetComponent<MoleAnimatorAssigner>();
            if (animatorAssigner != null)
            {
                animatorAssigner.AssignRandomAnimator(); // �����_���ȃA�j���[�^�[�����蓖�Ă�
            }
        }
    }
}