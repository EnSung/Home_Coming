using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    public void OnStartBtn()
    {
        SceneManager.LoadScene("IngameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
