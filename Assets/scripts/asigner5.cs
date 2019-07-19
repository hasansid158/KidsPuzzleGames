using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asigner5 : MonoBehaviour
{
    public Sprite[] imgs;
    public int count;
    public GameObject bgRight;
    void Start()
    {
        for (int a = 0; a < imgs.Length; a++)
        {
            GetComponent<touchMove5>().objsRight[a].GetComponent<SpriteRenderer>().sprite = imgs[a];
        }
    }
}
