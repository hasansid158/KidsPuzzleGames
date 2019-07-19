using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchMove5 : MonoBehaviour
{
    public GameObject[] objsRight, objDark;
    RaycastHit2D hits;
    int ind;
    Vector3[] movPos;
    bool pressed;
    Vector3[] sizes;
    bool once;
    public AudioSource soundCont;
    public AudioClip pickedSound;

    void Start()
    {
        movPos = new Vector3[objsRight.Length];
        sizes = new Vector3[objDark.Length];

        for (int a = 0; a < objsRight.Length; a++)
        {
            movPos[a] = objsRight[a].transform.position;
            sizes[a] = objsRight[a].transform.localScale;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hits = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            for (int a = 0; a < objsRight.Length; a++)
            {
                if (hits.collider == objsRight[a].GetComponent<Collider2D>())
                {
                    ind = a;
                    Destroy(objsRight[a].GetComponent<Rigidbody2D>());
                    objsRight[a].GetComponent<BoxCollider2D>().isTrigger = true;
                    objsRight[a].GetComponent<SpriteRenderer>().sortingOrder = 6;
                    pressed = true;
                    once = true;
                    soundCont.PlayOneShot(pickedSound, 1);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            objsRight[ind].GetComponent<SpriteRenderer>().sortingOrder = 5;
            pressed = false;
        }
        if (pressed)
        {
            movPos[ind] = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            sizes[ind] = objDark[ind].transform.localScale;
        }

        if (once)
        {
            objsRight[ind].transform.position = Vector3.Lerp(objsRight[ind].transform.position, movPos[ind], 12f * Time.deltaTime);
            objsRight[ind].transform.localScale = Vector3.Lerp(objsRight[ind].transform.localScale, sizes[ind], 6 * Time.deltaTime);
        }
    }
}
