using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
        Gamemanager.Instance.OnGameStart();
    }

    public void QuitGame()
    {
        // �ֿܼ����� �۵����� ������, ����� ���ø����̼ǿ��� ���� ����
        Application.Quit();
    }
}
