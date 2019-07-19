using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchMove3 : MonoBehaviour
{
    public GameObject[] shapes;
    Vector3[] startPos, movPos;
    RaycastHit2D hit;
    int indx;
    bool pressed;
    public GameObject darkShape, wand;

    public AudioClip[] voiceOvers;
    public AudioClip puzzlePick;

    void Start()
    {
        startPos = new Vector3[shapes.Length];
        movPos = new Vector3[shapes.Length];
        StartCoroutine(startWait());
        StartCoroutine(shapeColOn());
    }

    IEnumerator startWait()
    {
        for (int b = 0; b < shapes.Length; b++)
        {
            startPos[b] = shapes[b].transform.position;
            movPos[b] = startPos[b];
        }
        wand.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
        GetComponent<assigner3>().asginNow();
        for (int b = 0; b < shapes.Length; b++)
        {
            shapes[b].GetComponent<Animation>().Play();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            for (int a = 0; a < shapes.Length; a++)
            {
                if (hit.collider == shapes[a].GetComponent<CircleCollider2D>())
                {
                    for (int x = 0; x < voiceOvers.Length; x++)
                    {
                        if (hit.collider.GetComponent<SpriteRenderer>().sprite == GetComponent<assigner3>().shapeImgs[x])
                        {
                            GetComponent<AudioSource>().Stop();
                            GetComponent<AudioSource>().PlayOneShot(voiceOvers[x],1);
                        }
                    }
                    GetComponent<AudioSource>().PlayOneShot(puzzlePick,1);
                    indx = a;
                    pressed = true;
                    shapes[a].GetComponent<SpriteRenderer>().sortingOrder = 7;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine("colOn");
            StartCoroutine("colOn");
            pressed = false;
            shapes[indx].GetComponent<SpriteRenderer>().sortingOrder = 6;
        }

        for (int b = 0; b < shapes.Length; b++)
        {
            if (!shapes[b].GetComponent<Animation>().isPlaying)
            {
                shapes[b].transform.position = Vector3.Slerp(shapes[b].transform.position, movPos[b], 3 * Time.deltaTime);

                if (pressed)
                {
                    movPos[indx] = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                    shapes[indx].transform.position = Vector3.Lerp(shapes[indx].transform.position, movPos[indx], 5 * Time.deltaTime);
                }
                else if(!pressed)
                {
                    movPos[indx] = startPos[indx];
                }
            }
        }
    }

    IEnumerator shapeColOn()
    {
        yield return new WaitForSeconds(2);
        for (int a = 0; a < shapes.Length; a++)
        {
            shapes[a].GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    IEnumerator colOn()
    {
        if (!darkShape.GetComponent<Animation>().isPlaying)
        {
            darkShape.GetComponent<CircleCollider2D>().enabled = true;
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            darkShape.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
