using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    public float speed = 5;
    Transform current_goalPos;

    void Start()
    {
        
    }

    void Update()
    {
        if (IngameManager.Instance.playerTrackPos.Count == 0) return;

        if (current_goalPos == null || current_goalPos.position == transform.position)
            current_goalPos = IngameManager.Instance.playerTrackPos.Dequeue();


        transform.position = Vector2.MoveTowards(transform.position,current_goalPos.position, speed * Time.deltaTime);
    
        
    }
}
