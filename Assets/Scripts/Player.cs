using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float applySpeed = 5f;

    public float stemina = 10;
    public Light2D light;

    Rigidbody2D rb;
    Vector2 Pre_Pos;

    public Animator anim;
    public SpriteRenderer SR;

    public LayerMask itemMask;

    bool isGrounded;
    bool isMoving;

    public AudioSource audioSrc;
    public AudioClip jumpClip;
    void Start()
    {
        IngameManager.Instance.player = this;
        rb = GetComponent<Rigidbody2D>();
        light = GetComponentInChildren<Light2D>();
        anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        StartCoroutine(TrackCreateCor());
        
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(h,0) * applySpeed * Time.deltaTime;

        anim.SetInteger("h", (int)h);
        if (h < 0) SR.flipX = true;
        else if (h > 0) SR.flipX = false;
        else;
        isMoving = (h != 0 && isGrounded) ? true : false;

        if (isMoving)
        {
            if(!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else audioSrc.Stop();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, 350));
            SoundManager.Instance.SFXPlay("Jup", jumpClip);
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
        if(stemina < 0)
            stemina = 0;

        light.pointLightOuterRadius = stemina;
    }

    public void OnHeal(float heal)
    {
        stemina += heal;
        if(stemina > 8)
            stemina = 8;

        light.pointLightOuterRadius = stemina;
        StartCoroutine(SpeedIncreaseCor());
    }


    public void OnTrap()
    {
        StartCoroutine(TrapCor());
    }

    IEnumerator TrapCor()
    {
        yield return null;

        float sepd = speed - 0.4f;

        applySpeed = sepd;

        yield return new WaitForSeconds(1.3f);

        applySpeed = speed;
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
        else if (collision.CompareTag("DeadLine"))
        {
            IngameManager.Instance.Gameover();
        }
    }

}
