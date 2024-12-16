using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInicio : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Cursor.visible = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
    public void Exit()
    {
        Cursor.visible = true;
        Application.Quit();
    }
}
