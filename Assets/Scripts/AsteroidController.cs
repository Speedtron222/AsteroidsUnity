using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float minSpeed = 75;
    public float maxSpeed = 225;
    Rigidbody2D rb;
    public AsteroidGenerator generator;
    public GameObject explodeEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction = direction * Random.Range(minSpeed, maxSpeed);
        rb.AddForce(direction);
        generator.astCount += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        if (transform.localScale.x > 0.25f)
        {
            GameObject tempAst1 = Instantiate(generator.asteroid, transform.position, transform.rotation);
            GameObject tempAst2 = Instantiate(generator.asteroid, transform.position, transform.rotation);
            tempAst1.GetComponent<AsteroidController>().generator = generator;
            tempAst2.GetComponent<AsteroidController>().generator = generator;
            tempAst1.transform.localScale = transform.localScale * 0.5f;
            tempAst2.transform.localScale = transform.localScale * 0.5f;
        }
        GameObject tempPart = Instantiate(explodeEffect, transform.position, transform.rotation);
        Destroy(tempPart, 6f);
        Destroy(gameObject);
        Gears.instance.score += 100;
        generator.astCount -= 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().Death();
        }
    }
}
