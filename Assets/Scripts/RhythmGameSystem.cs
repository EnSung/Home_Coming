using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum NoteType
{
    Left = 0, Up, Down, Right
}
public class RhythmGameSystem : MonoBehaviour
{
    public Queue<Note> LeftArrowQueue = new Queue<Note>(); // 임시
    public Queue<Note> UpArrowQueue = new Queue<Note>(); // 임시
    public Queue<Note> DownArrowQueue = new Queue<Note>(); // 임시
    public Queue<Note> RightArrowQueue = new Queue<Note>(); // 임시

    public Transform[] noteSpawnPos; // [L, R, U, D]

    public GameObject notePrefab;


    public AudioClip[] SingClip;
    public AudioClip noteSound;
    void Start()
    {


    }

    void Update()
    {
        if (LeftArrowQueue.Count == 0 && RightArrowQueue.Count == 0 && UpArrowQueue.Count == 0 && DownArrowQueue.Count == 0) gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            JudgeNote(NoteType.Left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            JudgeNote(NoteType.Up);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            JudgeNote(NoteType.Down);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            JudgeNote(NoteType.Right);

        }
    }

    /// <summary>
    /// 노트 생성 함수
    /// </summary>
    /// <param name="type"></param>
    /// <param name="hitTime"></param>
    public void CreateNote(NoteType type, double hitTime)
    {

        Note note = Instantiate(notePrefab, transform.position, Quaternion.identity).GetComponent<Note>();
        note.Initialize(hitTime);
        switch (type)
        {
            case NoteType.Left:
                LeftArrowQueue.Enqueue(note);
                note.gameObject.transform.position = new Vector2(noteSpawnPos[0].position.x, note.transform.position.y);
                note.type = NoteType.Left;
                break;
            case NoteType.Up:
                note.gameObject.transform.position = new Vector2(noteSpawnPos[1].position.x, note.transform.position.y);
                UpArrowQueue.Enqueue(note);
                note.type = NoteType.Up;
                break;
            case NoteType.Down:
                note.gameObject.transform.position = new Vector2(noteSpawnPos[2].position.x, note.transform.position.y);
                DownArrowQueue.Enqueue(note);
                note.type = NoteType.Down;
                break;
            case NoteType.Right:
                RightArrowQueue.Enqueue(note);
                note.gameObject.transform.position = new Vector2(noteSpawnPos[3].position.x, note.transform.position.y);
                note.type = NoteType.Right;
                break;
            default:
                break;
        }


        note.transform.parent = IngameManager.Instance.player.transform;
    }


    /// <summary>
    /// 노트 판정 함수
    /// </summary>
    /// <param name="type"></param>
    public void JudgeNote(NoteType type)
    {

        //시간 계산
        Note note = null;
        switch (type)
        {
            case NoteType.Left:
                note = LeftArrowQueue?.Peek();
                break;

            case NoteType.Up:
                note = UpArrowQueue?.Peek();
                break;
            case NoteType.Down:
                note = DownArrowQueue?.Peek();
                break;
            case NoteType.Right:
                note = RightArrowQueue?.Peek();
                break;
            default:
                break;
        }

        if (note == null)
        {
            Debug.Log("note null");
            return;

        }
        double judgeStandardTime = Mathf.Abs((float)note.hitTime - Time.time);

        //판정
        if (judgeStandardTime <= 0.2f) // 퍼펙
        {
            Debug.Log("Perfect");
            switch (type)
            {
                case NoteType.Left:
                    note = LeftArrowQueue.Dequeue();
                    break;

                case NoteType.Up:
                    note = UpArrowQueue.Dequeue();
                    break;
                case NoteType.Down:
                    note = DownArrowQueue.Dequeue();
                    break;
                case NoteType.Right:
                    note = RightArrowQueue.Dequeue();
                    break;
                default:
                    break;
            }

            SoundManager.Instance.SFXPlay("noteS", noteSound);
            Destroy(note.gameObject);
        }
        else if (judgeStandardTime <= 0.28f) // 노멀
        {
            Debug.Log("normal");
            switch (type)
            {
                case NoteType.Left:
                    note = LeftArrowQueue.Dequeue();
                    break;

                case NoteType.Up:
                    note = UpArrowQueue.Dequeue();
                    break;
                case NoteType.Down:
                    note = DownArrowQueue.Dequeue();
                    break;
                case NoteType.Right:
                    note = RightArrowQueue.Dequeue();
                    break;
                default:
                    break;
            }
            SoundManager.Instance.SFXPlay("noteS", noteSound);

            Destroy(note.gameObject);
        }
    }


    public void PlayRhythmGame()
    {
        LeftArrowQueue.Clear();
        UpArrowQueue.Clear();
        DownArrowQueue.Clear();
        RightArrowQueue.Clear();
        gameObject.SetActive(true);
        StartCoroutine(RhythmGameCor());
    }


    IEnumerator RhythmGameCor()
    {
        int i = 1;
        int rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + .4f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + .8f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 1f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 1.4f);
        rand = Random.Range(0, 4);
        //CreateNote((NoteType)rand, i + 1.6f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 1.8f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 2f);
        //
        rand = Random.Range(0, 4);
        //CreateNote((NoteType)rand, i + 2.4f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 2.8f);
        rand = Random.Range(0, 4);
        //CreateNote((NoteType)rand, i + 3f);
        rand = Random.Range(0, 4);
        //CreateNote((NoteType)rand, i + 3.4f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 3.6f);
        rand = Random.Range(0, 4);
        //CreateNote((NoteType)rand, i + 3.8f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 4f);
        rand = Random.Range(0, 4);
        //CreateNote((NoteType)rand, i + 4.4f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 4.8f);
        rand = Random.Range(0, 4);
        //CreateNote((NoteType)rand, i + 5f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 5.4f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 5.6f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 5.8f);
        rand = Random.Range(0, 4);
        CreateNote((NoteType)rand, i + 6f);

        yield return new WaitForSeconds(1);
        var Sound = SoundManager.Instance.SFXPlay("rhythmgameClip", SingClip[0]);


    }
}
