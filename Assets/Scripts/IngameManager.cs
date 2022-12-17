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

    public RhythmGameSystem RhythmGame;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
      

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RhythmGame.PlayRhythmGame();
        }


    }
}
