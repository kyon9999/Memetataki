using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Mole : MonoBehaviour
{
    private Animator animator;
    private Collider2D moleCollider;
    private Image imageComponent;
    public List<Sprite> moleSprites;

    private AudioSource audioSource;
    public List<AudioClip> audioClips;

    private bool isHit = false; // 連続で叩かれるのを防ぐフラグ

    void Start()
    {
        animator = GetComponent<Animator>();
        moleCollider = GetComponent<Collider2D>();
        imageComponent = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        UpdateSprite();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hummer") && !isHit)
        {
            isHit = true; // 叩かれたことを記録
            Debug.Log("モグラが叩かれた！");

            animator.SetBool("MemeReturn", true);
            Debug.Log("MemeReturn を true に設定");

            PlayRandomAudioClip();
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        ScoreManager.Instance.AddScore(1);

        animator.SetTrigger("MemeFreeze");
        StartCoroutine(WaitForAnimationAndReset("MemeFreeze")); // 修正：アニメーションが終わるのを待ってリセット
    }

    private IEnumerator WaitForAnimationAndReset(string animationName)
    {
        yield return new WaitForSeconds(1.5f); // 少し待機してからリセット
        
        animator.SetBool("MemeReturn", false);
        isHit = false; // 叩かれるのを解除
        MoleAnimater();
        UpdateSprite();
        Debug.Log("MemeReturn を false に設定");
    }

    private void UpdateSprite()
    {
        if (imageComponent != null && moleSprites.Count > 0)
        {
            int randomIndex = Random.Range(0, moleSprites.Count);
            imageComponent.sprite = moleSprites[randomIndex];
        }
    }

    private void MoleAnimater()
    {
        MoleAnimatorAssigner animatorAssigner = GetComponent<MoleAnimatorAssigner>();
        if (animatorAssigner != null)
        {
            animatorAssigner.AssignRandomAnimator();
        }
    }

    private void PlayRandomAudioClip()
    {
        if (audioSource != null && audioClips.Count > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Count);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
        }
    }
}
