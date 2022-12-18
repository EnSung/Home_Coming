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
            (calcTime) * 10 + IngameManager.Instance.RhythmGame.noteSpawnPos[0].position.y/*판정 UI 포지션*/);

        if (calcTime < -.5f)//*마지막 판정 바로 다음으로 시간 설정*//*)
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
