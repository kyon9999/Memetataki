using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void OnBackButtonPress()
    {
        GameManager.Instance.ReturnStartMenu(); // GameManager�̃��\�b�h���Ăяo��
    }
}