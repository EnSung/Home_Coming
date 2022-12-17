using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    float stemina = 9;
    public Light2D light;

    Rigidbody2D rb;
    Vector2 move;

    Vector2 Pre_Pos;
    void Start()
    {
        IngameManager.Instance.player = this;
        rb = GetComponent<Rigidbody2D>();
        light = GetComponentInChildren<Light2D>();
        StartCoroutine(TrackCreateCor());
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),0) * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, 300));
        }

        else if (Input.GetKeyDown(KeyCode.K))
        {
            OnDamaged(1);
        }

    }

    public void OnDamaged(float damaged)
    {
        stemina -= damaged;

        light.pointLightOuterRadius = stemina;
    }

    IEnumerator TrackCreateCor()
    {
        while (true)
        {
            yield return null;

            if (transform.position == (Vector3)Pre_Pos) { }
            else
            {
                IngameManager.Instance.playerTrackPos.Enqueue(transform);
            }

            yield return new WaitForSeconds(1.2f);

        }
    }

    
}
