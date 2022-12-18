using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Vector2 hitBox;

    bool isAttack;
    public Sprite active;
    public LayerMask playerMask;

    public AudioClip trapCLip;

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
            GetComponent<SpriteRenderer>().sprite = active;
            if(col != null)
            {
                IngameManager.Instance.player.OnDamaged(2);
                IngameManager.Instance.player.OnTrap();
                SoundManager.Instance.SFXPlay("trap", trapCLip);
                Debug.Log("hit!!");
            }
            
            isAttack = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, hitBox);
    }
}
