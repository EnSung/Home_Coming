using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Note : MonoBehaviour
{
    public double hitTime;
    public NoteType type;

    void Start()
    {
        
    }

    void Update()
    {
        float calcTime = (float)hitTime - Time.time;
        transform.position = new Vector2(transform.position.x,
            (calcTime) * 10 + IngameManager.Instance.RhythmGame.noteSpawnPos[0].position.y/*���� UI ������*/);

        if (calcTime < -.5f)//*������ ���� �ٷ� �������� �ð� ����*//*)
        {
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

            IngameManager.Instance.player.OnDamaged(1);
            Destroy(gameObject);
            SoundManager.Instance.SFXPlay("Miss", IngameManager.Instance.RhythmGame.missSound);

            Debug.Log("Miss");
            
        }
    }

    public void Initialize(double time)
    {
        hitTime = Time.time + time;
    }
}
