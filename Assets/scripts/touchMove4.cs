using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchMove4 : MonoBehaviour
{
    public GameObject[] objs;
    RaycastHit2D hit;
    public Vector3[] startPos, movPos;
    int indx;
    bool pressed;
    public GameObject[] boxes;
    public GameObject soundCont;
    public AudioClip picked;

    void Start()
    {
        startPos = new Vector3[objs.Length];
        movPos = new Vector3[objs.Length];

        for (int a = 0; a < startPos.Length; a++)
        {
            startPos[a] = objs[a].transform.position;
            movPos[a] = startPos[a];
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);

            for (int x = 0; x < objs.Length; x++)
            {
                if (hit.collider == objs[x].GetComponent<CircleCollider2D>())
                {
                    indx = x;
                    pressed = true;
                    objs[x].GetComponent<SpriteRenderer>().sortingOrder = 7;
                    soundCont.GetComponent<AudioSource>().PlayOneShot(picked, 1);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
            objs[indx].GetComponent<SpriteRenderer>().sortingOrder = 6;
            StopCoroutine("colOn");
            StartCoroutine("colOn");
        }

        for (int b = 0; b < objs.Length; b++)
        {

            objs[b].transform.position = Vector3.Slerp(objs[b].transform.position, movPos[b], 2.2f * Time.deltaTime);

            if (pressed)
            {
                movPos[indx] = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                objs[indx].transform.position = Vector3.Lerp(objs[indx].transform.position, movPos[indx], 8 * Time.deltaTime);
            }
            else if (!pressed)
            {
                movPos[indx] = startPos[indx];
            }

        }
    }

    IEnumerator colOn()
    {
        for(int a = 0; a < boxes.Length; a++)
        {
            boxes[a].GetComponent<CircleCollider2D>().enabled = true;
        }
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        for (int a = 0; a < boxes.Length; a++)
        {
            boxes[a].GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
