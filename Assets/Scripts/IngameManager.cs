using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{

    #region Singleton
    static IngameManager instance;
    public static IngameManager Instance { get { return instance; } }

    #endregion

    public Player player;
    public Queue<Transform> playerTrackPos = new Queue<Transform>();

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    void Update()
    {
        
    }
}
