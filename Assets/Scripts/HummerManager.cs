using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{
    Animator animator;
    public GameObject hummerOJT;
    private Collider2D hammerCollider;

    // AudioSource�R���|�[�l���g
    private AudioSource audioSource;

    // ���ʉ���AudioClip
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
            mousePosition.z = Camera.main.nearClipPlane; // �K�v�ɉ�����z�ʒu��ݒ�
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            hummerOJT.transform.position = worldPosition;

            Debug.Log("Input detected");
            animator.SetTrigger("Move0");

            // ���ʉ��������_���ɍĐ�
            PlayRandomSound();
        }
    }

    void PlayRandomSound()
    {
        // �����_���Ɍ��ʉ���I��
        int randomIndex = Random.Range(0, 2); // 0�܂���1
        AudioClip selectedClip = randomIndex == 0 ? soundEffect1 : soundEffect2;

        // ���ʉ����Đ�
        audioSource.PlayOneShot(selectedClip);
    }
}
