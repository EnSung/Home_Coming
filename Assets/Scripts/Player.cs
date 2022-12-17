using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float applySpeed = 5f;

    float stemina = 9;
    public Light2D light;

    Rigidbody2D rb;
    Vector2 Pre_Pos;


    public LayerMask itemMask;

    bool isGrounded;
    void Start()
    {
        IngameManager.Instance.player = this;
        rb = GetComponent<Rigidbody2D>();
        light = GetComponentInChildren<Light2D>();
        StartCoroutine(TrackCreateCor());
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),0) * applySpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, 350));
        }


    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1, LayerMask.GetMask("Ground"));

        if (ray.collider == null)
            isGrounded = false;
        else isGrounded = true;

    }

    public void OnDamaged(float damaged)
    {
        stemina -= damaged;

        light.pointLightOuterRadius = stemina;
    }

    public void OnHeal(float heal)
    {
        stemina += heal;

        light.pointLightOuterRadius = stemina;
        StartCoroutine(SpeedIncreaseCor());
    }

    IEnumerator SpeedIncreaseCor()
    {
        yield return null;

        applySpeed = speed + 2;

        yield return new WaitForSeconds(3);

        applySpeed = speed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            collision.GetComponent<Item>().Use();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, Vector2.down);
    }
}
