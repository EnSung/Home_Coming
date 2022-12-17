using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(IngameManager.Instance.player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, IngameManager.Instance.player.transform.position.y,10 * Time.deltaTime),transform.position.z);
    }
}
