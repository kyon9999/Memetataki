using UnityEngine;
using UnityEngine.UI;

public class MaskControl : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RectMask2D rectMask;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rectMask = GetComponentInParent<RectMask2D>(); // RectMask2D�R���|�[�l���g���擾
    }

    private void Update()
    {
        // RectMask2D���ɂ��邩�m�F����
        if (IsInsideMask())
        {
            // BoxCollider��L���ɂ���
            boxCollider.enabled = true; // �R���C�_�[��L���ɂ���
        }
        else
        {
            // BoxCollider�𖳌��ɂ���
            boxCollider.enabled = false; // �R���C�_�[�𖳌��ɂ���
        }
    }

    private bool IsInsideMask()
    {
        // �I�u�W�F�N�g�̈ʒu���擾
        Vector3 objectPosition = transform.position;

        // RectMask2D�̈ʒu���l�����āA�I�u�W�F�N�g�̃��[�J�����W���擾
        Vector2 localPosition = rectMask.transform.InverseTransformPoint(objectPosition);

        // RectMask2D�͈̔͂��擾
        Rect maskRect = rectMask.rectTransform.rect;

        // ���[�J�����W��RectMask2D�͈͓̔������`�F�b�N
        return maskRect.Contains(localPosition);
    }
}