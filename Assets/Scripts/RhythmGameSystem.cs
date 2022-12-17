using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum NoteType
{
    Left,  Up, Down, Right
}
public class RhythmGameSystem : MonoBehaviour
{
    Queue<Note> LeftArrowQueue = new Queue<Note>(); // �ӽ�
    Queue<Note> UpArrowQueue = new Queue<Note>(); // �ӽ�
    Queue<Note> DownArrowQueue = new Queue<Note>(); // �ӽ�
    Queue<Note> RightArrowQueue = new Queue<Note>(); // �ӽ�

    public Transform[] noteSpawnPos; // [L, R, U, D]

    public GameObject notePrefab;
    void Start()
    {

        CreateNote(NoteType.Left, 2);
        CreateNote(NoteType.Up, 3);
        CreateNote(NoteType.Down, 6);
        CreateNote(NoteType.Right, 7);
    }

    void Update()
    {
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
    /// ��Ʈ ���� �Լ�
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
                break;
            case NoteType.Up:
                note.gameObject.transform.position = new Vector2(noteSpawnPos[1].position.x, note.transform.position.y);
                UpArrowQueue.Enqueue(note);
                break;
            case NoteType.Down:
                note.gameObject.transform.position = new Vector2(noteSpawnPos[2].position.x, note.transform.position.y);
                DownArrowQueue.Enqueue(note);
                break;
            case NoteType.Right:
                RightArrowQueue.Enqueue(note);
                note.gameObject.transform.position = new Vector2(noteSpawnPos[3].position.x, note.transform.position.y);
                break;
            default:
                break;
        }
    }


    /// <summary>
    /// ��Ʈ ���� �Լ�
    /// </summary>
    /// <param name="type"></param>
    public void JudgeNote(NoteType type)
    {
        Debug.Log(type.ToString());

        //�ð� ���
        Note note = null;
        switch (type)
        {
            case NoteType.Left:
                note = LeftArrowQueue.Peek();
                break;
            
            case NoteType.Up:
                note = UpArrowQueue.Peek();
                break;
            case NoteType.Down:
                note = DownArrowQueue.Peek();
                break;
            case NoteType.Right:
                note = RightArrowQueue.Peek();
                break;
            default:
                break;
        }

        if (note == null) return;

        double judgeStandardTime = Mathf.Abs((float)note.hitTime - Time.time);

        //����
        if (judgeStandardTime <= 0.05f) // ����
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

            Destroy(note.gameObject);
        }
        else if (judgeStandardTime <= 0.02f) // ���
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

            Destroy(note.gameObject);
        }
    }
}
