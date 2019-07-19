using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMover : MonoBehaviour
{
    public GameObject bg;
    public float bgValue;

    void Update()
    {
        bg.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(transform.position.x * bgValue * Time.fixedDeltaTime, bg.GetComponent<Renderer>().material.mainTextureOffset.y);
    }
}
