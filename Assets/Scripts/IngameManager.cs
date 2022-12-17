using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IngameManager : MonoBehaviour
{

    #region Singleton
    static IngameManager instance;
    public static IngameManager Instance { get { return instance; } }

    #endregion

    public Player player;
    public Queue<Transform> playerTrackPos = new Queue<Transform>();

    public RhythmGameSystem RhythmGame;

    public UnityEvent gameoverEvent;
    public bool isGameover;

    public AudioClip ghostLaughingClip;
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

    public void Gameover()
    {
        if (isGameover) return;
        gameoverEvent.Invoke();
        isGameover = true;
        SoundManager.Instance.SFXPlay("ghost Laugh", ghostLaughingClip);
    }
}
