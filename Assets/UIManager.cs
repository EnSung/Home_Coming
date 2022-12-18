using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject gameoverPanel;
    public GameObject clearPanel;

    public void Gameover()
    {
        StartCoroutine(gameoverCor());
    }
    public void Clear()
    {
        //StartCoroutine(ClearCor());
        clearPanel.SetActive(true);
    }


    IEnumerator gameoverCor()
    {
        gameoverPanel.SetActive(true);
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("MainScene");
    }

    /*IEnumerator ClearCor()
    {

    }*/

    public void OnMainBtn()
    {
        SceneManager.LoadScene("MainScene");
        SoundManager.Instance.bgSound.Stop();
    }
}
