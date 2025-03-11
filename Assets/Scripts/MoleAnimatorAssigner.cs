using UnityEngine;
using System.Collections.Generic;

public class MoleAnimatorAssigner : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.Instance.isGameActive)
        {
            return; // �Q�[������A�N�e�B�u�ȏꍇ�A�����𒆒f
        }

        // �Q�[�����A�N�e�B�u�ȏꍇ�̃��W�b�N�������ɋL�q
    }
    public List<RuntimeAnimatorController> animatorControllers;

    // �A�j���[�^�[�����蓖�Ă郁�\�b�h
    public void AssignRandomAnimator()
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null && animatorControllers.Count > 0)
        {
            int randomIndex = Random.Range(0, animatorControllers.Count);
            animator.runtimeAnimatorController = animatorControllers[randomIndex];
        }
    }
}