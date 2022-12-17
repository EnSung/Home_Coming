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
    public AudioClip bgmClip;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        SoundManager.Instance.BgSoundPlay(bgmClip);
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
        SoundManager.Instance.bgSound.Stop();
        SoundManager.Instance.SFXPlay("ghost Laugh", ghostLaughingClip);
    }

    public void HomeComing()
    {

    }
    IEnumerator rhythmCor()
    {
        bool i = false;
        while (true)
        {

            float randTime = Random.Range(13f, 18f);
            SoundManager.Instance.bgSound.volume = .5f;

            yield return null;
            if (!i)
            {
                randTime = Random.Range(2f, 4f);
                i = true;
            }
            yield return new WaitForSeconds(randTime);


            SoundManager.Instance.SFXPlay("skill", ghostSkillClip);
            SoundManager.Instance.bgSound.Stop();
            RhythmGame.PlayRhythmGame();



        }
    }
}
