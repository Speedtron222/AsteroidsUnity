using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public int minAst = 2;
    public int maxAst = 6;
    public int astCount = 0;
    int border = 0;
    public GameObject asteroid;
    public float Xlimit = 11;
    public float Ylimit = 6;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(astCount <= 0)
        {
            if(minAst < 10)
            {
                minAst += 1;
            }
            if(maxAst < 10)
            {
                maxAst += 1;
            }
            Create();
        }
    }

    void Create()
    {
        int ast = Random.Range(minAst, maxAst);
        for (int i = 0; i < ast; i++)
        {
            if(Random.Range(-1, 1) >= 0)
            {
                border = 1;
            } else
            {
                border = -1;
            }
            Vector3 position = new Vector3(border*Xlimit, border*Ylimit, 0);
            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject tempAst = Instantiate(asteroid, position, Quaternion.Euler(rotation));
            tempAst.GetComponent<AsteroidController>().generator = this;
        }
    }

}
