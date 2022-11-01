using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : MonoBehaviour
{
    public static Gears instance;
    public int gears = 3;
    public int score = 0;
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
