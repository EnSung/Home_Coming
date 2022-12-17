using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(IngameManager.Instance.player.transform.position.x +8.592f, 3f);
    }
}
