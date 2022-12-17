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
    public AudioClip ghostSkillClip;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {

        StartCoroutine(rhythmCor());
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

    IEnumerator rhythmCor()
    {
        bool i = false;
        while (true)
        {
            float randTime = Random.Range(8f, 11f);
            yield return null;
            if (!i)
            {
                randTime = Random.Range(2f, 4f);
                i = true;
            }
            yield return new WaitForSeconds(randTime);


            RhythmGame.PlayRhythmGame();



        }
    }
}
