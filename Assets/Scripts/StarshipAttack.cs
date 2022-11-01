using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipAttack : MonoBehaviour
{
    public float speed = 100f;
    public float spawnRate = 60f;
    public float fireRate = 0.5f;
    public GameObject redBullet;
    public GameObject shooter;
    Rigidbody2D rb;
    bool minute = false;
    bool reload = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(timeCounter_Coroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= -11 && transform.position.x <=11 && !reload)
        {
            shooter.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            reload = true;
            StartCoroutine(RedShot_Coroutine());
        }
        if(transform.position.x > 11)
        {
            Reset();
        }
        if (Gears.instance.score >= 1000 && minute)
        {
            Vector2 direction = new Vector2(1, 0);
            direction = direction * speed;
            rb.AddForce(direction);
            minute = false;
            StartCoroutine(timeCounter_Coroutine());
        }
    }

    IEnumerator timeCounter_Coroutine()
    {
        yield return new WaitForSeconds(spawnRate);
        minute = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().Death();
        }
    }

    IEnumerator RedShot_Coroutine()
    {
        yield return new WaitForSeconds(fireRate);
        GameObject proj = Instantiate(redBullet, shooter.transform.position, shooter.transform.rotation);
        Destroy(proj, 3f);
        reload = false;
    }

    public void Reset()
    {
        transform.position = new Vector3(-14, 0, 0);
        rb.velocity = new Vector2(0, 0);
    }
}
