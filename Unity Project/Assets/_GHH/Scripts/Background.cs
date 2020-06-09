using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Material mat;
    public float scrollSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        //mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundScroll();
    }

    private void BackgroundScroll()
    {
        Vector2 offset = mat.mainTextureOffset;
        //offset.y += scrollSpeed * Time.deltaTime;
        offset.Set(0, offset.y + (scrollSpeed * Time.deltaTime));
        mat.mainTextureOffset = offset;
    }
}
