using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{
    Animator animator;
    public GameObject hummerOJT;
    private Collider2D hammerCollider;

    // AudioSourceコンポーネント
    private AudioSource audioSource;

    // 効果音のAudioClip
    public AudioClip soundEffect1;
    public AudioClip soundEffect2;

    void Start()
    {
        animator = GetComponent<Animator>();
        hammerCollider = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane; // 必要に応じてz位置を設定
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            hummerOJT.transform.position = worldPosition;

            Debug.Log("Input detected");
            animator.SetTrigger("Move0");

            // 効果音をランダムに再生
            PlayRandomSound();
        }
    }

    void PlayRandomSound()
    {
        // ランダムに効果音を選択
        int randomIndex = Random.Range(0, 2); // 0または1
        AudioClip selectedClip = randomIndex == 0 ? soundEffect1 : soundEffect2;

        // 効果音を再生
        audioSource.PlayOneShot(selectedClip);
    }
}
