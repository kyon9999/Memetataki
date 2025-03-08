using UnityEngine;
using System.Collections.Generic;

public class MoleAnimatorAssigner : MonoBehaviour
{
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