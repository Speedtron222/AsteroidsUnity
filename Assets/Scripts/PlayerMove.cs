using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove PM;
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D colliderBeetle;
    SpriteRenderer sprite;
    public float speed = 100;
    public float rotSpeed = 300;
    public float fireRate = 0.2f;
    public float brakeCD = 10f;
    public GameObject bullet;
    public GameObject barrel;
    public GameObject dieEffect;
    bool isDead = false;
    bool shotEnd = true;
    public bool canBrake = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colliderBeetle = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        PM = this;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Moving", true);
        } else
        {
            anim.SetBool("Moving", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal * -(rotSpeed) * Time.deltaTime);

        if (Input.GetButton("Jump") && !isDead && shotEnd)
        {
            shotEnd = false;
            StartCoroutine(ShotDelay_Coroutine());
        }
        if (vertical < 0 && canBrake)
        {
            canBrake = false;
            rb.velocity = new Vector2(0, 0);
            StartCoroutine(Brake_Coroutine());
        }
    }

    public void Death()
    {
        GameObject tempPart = Instantiate(dieEffect, transform.position, transform.rotation);
        Destroy(tempPart, 6f);
        colliderBeetle.enabled = false;
        sprite.enabled = false;
        isDead = true;
        if(Gears.instance.gears <= 0)
        {
           Destroy(gameObject);
        }
        Gears.instance.gears -= 1;
        StartCoroutine(Respawn_Coroutine());
    }

    IEnumerator Respawn_Coroutine()
    {
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);
        sprite.enabled = true;
        StartCoroutine(RespawnInvincible_Coroutine());
    }

    IEnumerator RespawnInvincible_Coroutine()
    {
        yield return new WaitForSeconds(2);
        colliderBeetle.enabled = true;
        isDead = false;
    }

    IEnumerator ShotDelay_Coroutine()
    {
        yield return new WaitForSeconds(fireRate);
        GameObject proj = Instantiate(bullet, barrel.transform.position, transform.rotation);
        Destroy(proj, 3f);
        shotEnd = true;
    }

    IEnumerator Brake_Coroutine()
    {
        yield return new WaitForSeconds(brakeCD);
        canBrake = true;
    }
}
