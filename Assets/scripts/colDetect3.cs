using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colDetect3 : MonoBehaviour
{
    public GameObject scripts, shapeIn;
    assigner3 aSc;
    int count;
    public ParticleSystem hatStarPart;
    public AudioClip placedAudio, finish;
    public GameObject rabbit, starHatLoop, but1, but2;

    void Start()
    {
        aSc = scripts.GetComponent<assigner3>();
        StartCoroutine(waitStartSound());
    }

    IEnumerator waitStartSound()
    {
        yield return new WaitForSeconds(1f);
        scripts.GetComponent<AudioSource>().PlayOneShot(finish, 0.7f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        for(int a = 0; a < aSc.shapeImgs.Length; a++)
        {
            if(gameObject.GetComponent<SpriteRenderer>().sprite == aSc.darkImgs[a])
            {
                if(col.gameObject.GetComponent<SpriteRenderer>().sprite == aSc.shapeImgs[a])
                {
                    shapeIn.GetComponent<SpriteRenderer>().sprite = aSc.shapeImgs[a];
                    shapeIn.GetComponent<Animation>().Play();
                    StopCoroutine("parWait");
                    StartCoroutine("parWait");
                    if (count <= 8)
                    {
                        aSc.darkAsign();
                    }
                    col.gameObject.SetActive(false);
                    count++;
                }
                else
                {
                    col.gameObject.GetComponent<Animation>().Play("wrongTouch");
                }
            }
        }
    }

    IEnumerator parWait()
    {
        gameObject.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.43f);
        scripts.GetComponent<AudioSource>().PlayOneShot(placedAudio, 1);
        hatStarPart.Play();
        if(count > 9)
        {
            scripts.GetComponent<AudioSource>().PlayOneShot(finish, 1);
            StartCoroutine(endingAnimWait());
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator endingAnimWait()
    {
        yield return new WaitForSeconds(0.5f);
        scripts.GetComponent<touchMove3>().wand.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.5f);
        starHatLoop.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1f);
        rabbit.SetActive(true);
        yield return new WaitForSeconds(1);
        but1.SetActive(true);
        but2.SetActive(true);
        gameObject.SetActive(false);
    }
}
