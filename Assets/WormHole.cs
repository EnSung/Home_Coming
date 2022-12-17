using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHole : MonoBehaviour
{
    public Vector2 hitBox;

    bool isAttack;

    public LayerMask playerMask;
    void Start()
    {
        
    }

    void Update()
    {
        if (Mathf.Abs(IngameManager.Instance.player.transform.position.x- transform.position.x) <= 0.2f && !isAttack) 
        {
            //АјАн
            Debug.Log("Attack");
            Collider2D col = Physics2D.OverlapBox(transform.position,hitBox,0,playerMask);

            if(col != null)
            {

            }
            
            isAttack = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, hitBox);
    }
}
