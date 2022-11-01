using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollingSpeed = 0.1f;
    float offset;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollingSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
