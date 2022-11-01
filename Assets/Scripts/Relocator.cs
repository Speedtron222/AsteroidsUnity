using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relocator : MonoBehaviour
{
    public float Xlimit = 11;
    public float Ylimit = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > Ylimit)
        {
            transform.position = new Vector3(transform.position.x, -Ylimit);
        }
        if (transform.position.y < -Ylimit)
        {
            transform.position = new Vector3(transform.position.x, Ylimit);
        }

        if (transform.position.x > Xlimit)
        {
            transform.position = new Vector3(-Xlimit, transform.position.y);
        }
        if (transform.position.x < -Xlimit)
        {
            transform.position = new Vector3(Xlimit, transform.position.y);
        }
    }
}
