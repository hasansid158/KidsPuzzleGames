using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseChecker : MonoBehaviour
{
    public toucher scripts;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "g")
        {
            scripts.tCharNum = 1;
        }
        else if (col.gameObject.tag == "p")
        {
            scripts.tCharNum = 2;
        }
        else if (col.gameObject.tag == "y")
        {
            scripts.tCharNum = 3;
        }
        else if (col.gameObject.tag == "no")
        {
            col.GetComponent<BoxCollider2D>().enabled = false;
            scripts.tCharNum = 0;
            scripts.housePlaceNum++;
        }
    }
}
