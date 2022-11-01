using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpearShot : MonoBehaviour
{
    public float spearSpeed = 500;
    Rigidbody2D rb;
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
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().Death();
            Destroy(gameObject);
        }
    }
}
