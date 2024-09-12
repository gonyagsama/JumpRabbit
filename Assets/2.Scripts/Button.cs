using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        // 콘솔에서는 작동하지 않지만, 빌드된 애플리케이션에서 게임 종료
        Application.Quit();
    }
}
