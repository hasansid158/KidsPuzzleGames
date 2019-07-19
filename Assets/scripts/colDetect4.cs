using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colDetect4 : MonoBehaviour
{
    public GameObject[] animIn1, animIn2, animIn3;
    public GameObject scripts;
    touchMove4 tSc;
    assigner4 aSc;
    public GameObject soundCont;
    public AudioClip placed, finish;
    public GameObject but1, but2;

    void Start()
    {
        tSc = scripts.GetComponent<touchMove4>();
        aSc = scripts.GetComponent<assigner4>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        for(int a = 0; a < tSc.boxes.Length; a++)
        {
            if (gameObject == tSc.boxes[a])
            {
                if (col.gameObject.transform.localScale == aSc.sizes[a])
                {
                    col.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    aSc.countIn++;
                    StopCoroutine("parWait");
                    StartCoroutine("parWait");

                    for(int b = 0; b < 3; b++)
                    {
                        if(animIn1[aSc.itemCount].transform.parent.gameObject == gameObject)
                        {
                            animIn1[aSc.itemCount].GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                            animIn1[aSc.itemCount].GetComponent<Animation>().Play();

                        }
                        else if (animIn2[aSc.itemCount].transform.parent.gameObject == gameObject)
                        {
                            animIn2[aSc.itemCount].GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                            animIn2[aSc.itemCount].GetComponent<Animation>().Play();

                        }
                        else if (animIn3[aSc.itemCount].transform.parent.gameObject == gameObject)
                        {
                            animIn3[aSc.itemCount].GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                            animIn3[aSc.itemCount].GetComponent<Animation>().Play();
                        }
                    }
                    col.gameObject.GetComponent<SpriteRenderer>().sprite = null;

                    aSc.count++;

                    if(aSc.count >= 3 && aSc.countIn < 27)
                    {
                        aSc.count = 0;
                        aSc.itemCount++;
                        aSc.asigner();
                    }
                }
                else
                {
                    col.gameObject.GetComponent<Animation>().Play();
                }
            }
        }
    }

    IEnumerator parWait()
    {
        if(aSc.countIn < 27)
        {
            yield return new WaitForSeconds(0.4f);
            soundCont.GetComponent<AudioSource>().PlayOneShot(placed, 1);
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
        else
        {
            yield return new WaitForSeconds(0.4f);
            soundCont.GetComponent<AudioSource>().PlayOneShot(placed, 1);
            soundCont.GetComponent<AudioSource>().PlayOneShot(finish, 1);
            for (int a = 0; a < tSc.boxes.Length; a++)
            {
                tSc.boxes[a].transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            }
            but1.SetActive(true);
            but2.SetActive(true);
        }
    }
}
