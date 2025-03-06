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

    private AudioSource audioSource; // この行を追加
    public List<AudioClip> audioClips; // この行を追加

    void Start()
    {
        animator = GetComponent<Animator>();
        moleCollider = GetComponent<Collider2D>();
        imageComponent = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>(); // この行を追加
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hummer"))
        {
            Debug.Log("衝突がおきた");
            // ステート1からステート2への遷移
            animator.SetBool("MemeReturn", true);
            Debug.Log("MemeReturnをtrueに設定");

            // ランダムな音声クリップを再生
            PlayRandomAudioClip(); // この行を追加
            
            // ダメージ処理を呼ぶ
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        ScoreManager.Instance.AddScore(1);

        animator.SetTrigger("MemeFreeze"); // ステート2からステート3への遷移

        StartCoroutine(ResetMemeReturn());//非同期処理スタート
    }

    private IEnumerator ResetMemeReturn()　//非同期処理
    {
        // 3つ目のアニメーションが終わったことを待つ
        yield return new WaitForSeconds(1.5f); // 適切な時間に調整
        animator.SetBool("MemeReturn", false); // ステート3からステート4への遷移
        MoleAnimater();
        UpdateSprite();
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

    private void MoleAnimater()
    {
        // MoleAnimatorAssignerを取得してメソッドを呼び出す
        MoleAnimatorAssigner animatorAssigner = GetComponent<MoleAnimatorAssigner>();
        if (animatorAssigner != null)
        {
            animatorAssigner.AssignRandomAnimator(); // ランダムなアニメーターを割り当てる
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