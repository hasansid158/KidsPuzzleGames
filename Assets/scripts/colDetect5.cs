using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colDetect5 : MonoBehaviour
{
    public Sprite[] darkImgs;
    public GameObject scripts;
    public GameObject partSmall;
    public GameObject[] partBig;
    public AudioSource soundCont;
    public AudioClip finish, placeSound;
    public GameObject but1, but2;

    void OnTriggerEnter2D(Collider2D col)
    {
        for (int a = 0; a < darkImgs.Length; a++)
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == darkImgs[a])
            {
                if (col.gameObject == scripts.GetComponent<touchMove5>().objsRight[a])
                {
                    GetComponent<Animation>().Play();
                    GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                    col.gameObject.SetActive(false);
                    partSmall.transform.position = transform.position;
                    soundCont.PlayOneShot(placeSound, 1);
                    partSmall.GetComponent<ParticleSystem>().Play();
                    scripts.GetComponent<asigner5>().count++;
                    if (scripts.GetComponent<asigner5>().count >= 12)
                    {
                        scripts.GetComponent<asigner5>().bgRight.SetActive(false);
                        soundCont.PlayOneShot(finish, 1);
                        StartCoroutine(endPart());
                    }
                }
            }
        }
    }
    IEnumerator endPart()
    {
        for(int a = 0; a < 25; a++)
        {
            for(int b = 0; b < partBig.Length; b++)
            {
                yield return new WaitForSeconds(Random.Range(0.2f, 0.8f));
                partBig[b].GetComponent<ParticleSystem>().Play();
            }
            yield return new WaitForSeconds(0.2f);
            but1.SetActive(true);
            but2.SetActive(true);
        }
    }
}
