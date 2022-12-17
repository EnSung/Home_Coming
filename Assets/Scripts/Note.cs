using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Note : MonoBehaviour
{

    UnityEvent MissEvent;
    public double hitTime;
    public NoteType type;

    void Start()
    {
        
    }

    void Update()
    {
        float calcTime = (float)hitTime - Time.time;
        transform.position = new Vector2(transform.position.x,
            (calcTime) * 20 - 4.41f/*���� UI ������*/);

        if (calcTime <= -0.5f/*������ ���� �ٷ� �������� �ð� ����*/)
        {
            MissEvent?.Invoke();
            switch (type)
            {
                case NoteType.Left:
                    IngameManager.Instance.RhythmGame.LeftArrowQueue.Dequeue();
                    break;
                case NoteType.Up:
                    IngameManager.Instance.RhythmGame.UpArrowQueue.Dequeue();
                    break;
                case NoteType.Down:
                    IngameManager.Instance.RhythmGame.DownArrowQueue.Dequeue();
                    break;
                case NoteType.Right:
                    IngameManager.Instance.RhythmGame.RightArrowQueue.Dequeue();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);

            Debug.Log("Miss");
            
        }
    }

    public void Initialize(double time)
    {
        hitTime = Time.time + time;
    }
}
