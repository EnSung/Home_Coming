using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Note : MonoBehaviour
{

    UnityEvent MissEvent;
    public double hitTime;
    NoteType type;

    void Start()
    {
        
    }

    void Update()
    {
        float calcTime = (float)hitTime - Time.time;
        transform.localPosition = new Vector2(transform.position.x,
            (calcTime) * 20 - 4.41f/*���� UI ������*/);

        if (calcTime <= -0.5f/*������ ���� �ٷ� �������� �ð� ����*/)
        {
            MissEvent?.Invoke();
            Destroy(gameObject);

            Debug.Log("Miss");
            
        }
    }

    public void Initialize(double time)
    {
        hitTime = Time.time + time;
    }
}
