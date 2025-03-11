using UnityEngine;
using System.Collections.Generic;

public class MoleAnimatorAssigner : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.Instance.isGameActive)
        {
            return; // ゲームが非アクティブな場合、処理を中断
        }

        // ゲームがアクティブな場合のロジックをここに記述
    }
    public List<RuntimeAnimatorController> animatorControllers;

    // アニメーターを割り当てるメソッド
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