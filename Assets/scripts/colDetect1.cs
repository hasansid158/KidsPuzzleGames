using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colDetect1 : MonoBehaviour
{
    public toucher touchSc;
    void OnTriggerEnter2D(Collider2D col)
    {
        for(int a = 0; a <= 2; a++)
        {
            if (gameObject == touchSc.ts[a])
            {
                if(col.gameObject == touchSc.charStop1[a])
                {
                    touchSc.trainColor[a].GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                    col.gameObject.SetActive(false);
                    touchSc.placed++;
                    if (touchSc.count >= 2)
                    {
                        touchSc.count = 0;
                        touchSc.animNum++;
                        Camera.main.GetComponent<Animation>().Play(touchSc.animNum.ToString());
                    }
                    else
                    {
                        touchSc.count++;
                    }
                    touchSc.sound.GetComponent<AudioSource>().PlayOneShot(touchSc.placeSound, 1);
                    transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                }
                else if (col.gameObject == touchSc.charStop2[a])
                {
                    touchSc.trainColor[a].GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                    col.gameObject.SetActive(false);
                    touchSc.placed++;
                    if (touchSc.count >= 2)
                    {
                        touchSc.count = 0;
                        touchSc.animNum++;
                        Camera.main.GetComponent<Animation>().Play(touchSc.animNum.ToString());
                    }
                    else
                    {
                        touchSc.count++;
                    }
                    touchSc.sound.GetComponent<AudioSource>().PlayOneShot(touchSc.placeSound, 1);
                    transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                }
                else if (col.gameObject == touchSc.charStop3[a])
                {
                    touchSc.trainColor[a].GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                    col.gameObject.SetActive(false);
                    touchSc.placed++;
                    if (touchSc.count >= 2)
                    {
                        touchSc.count = 0;
                        touchSc.animNum++;
                        Camera.main.GetComponent<Animation>().Play(touchSc.animNum.ToString());
                    }
                    else
                    {
                        touchSc.count++;
                    }
                    touchSc.sound.GetComponent<AudioSource>().PlayOneShot(touchSc.placeSound, 1);
                    transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }
}
