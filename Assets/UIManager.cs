using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject gameoverPanel;


    public void Gameover()
    {
        gameoverPanel.SetActive(true);
    }
}
