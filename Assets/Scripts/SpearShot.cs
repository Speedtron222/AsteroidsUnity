using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearShot : MonoBehaviour
{
    public float spearSpeed = 500;
    Rigidbody2D rb;
    public GameObject starshipDestroy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * spearSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<AsteroidController>().Break();
            Destroy(gameObject);
        }

        if (collision.tag == "Starship")
        {
            GameObject tempPart = Instantiate(starshipDestroy, transform.position, transform.rotation);
            Destroy(tempPart, 6f);
            collision.gameObject.GetComponent<StarshipAttack>().Reset();
            Destroy(gameObject);
            Gears.instance.score += 1000;
        }
    }
}
