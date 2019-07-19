using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseCol : MonoBehaviour
{
    public toucher touchSc;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!Camera.main.GetComponent<Animation>().isPlaying)
        {
            if (gameObject.tag == "green")
            {
                if (col.gameObject.tag == "green")
                {
                    for (int a = 0; a <= 2; a++)
                    {
                        touchSc.houseGreen[a].transform.GetChild(touchSc.housePlaceNum).GetComponent<SpriteRenderer>().sprite = col.GetComponent<SpriteRenderer>().sprite;
                    }
                    col.GetComponent<SpriteRenderer>().sprite = null;
                    col.transform.localPosition = new Vector3(0.59f, 0.41f, 0);
                    if (touchSc.animNum < 11)
                    {
                        touchSc.animNum++;
                        Camera.main.GetComponent<Animation>().Play(touchSc.animNum.ToString());
                    }
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    touchSc.sound.GetComponent<AudioSource>().PlayOneShot(touchSc.placeSound, 1);
                    touchSc.houseParticle.transform.position = transform.position;
                    touchSc.houseParticle.GetComponent<ParticleSystem>().Stop();
                    touchSc.houseParticle.GetComponent<ParticleSystem>().Play();
                }
            }

            else if (gameObject.tag == "purple")
            {
                if (col.gameObject.tag == "purple")
                {
                    for (int a = 0; a <= 2; a++)
                    {
                        touchSc.housePurple[a].transform.GetChild(touchSc.housePlaceNum).GetComponent<SpriteRenderer>().sprite = col.GetComponent<SpriteRenderer>().sprite;
                    }
                    col.GetComponent<SpriteRenderer>().sprite = null;
                    col.transform.localPosition = new Vector3(-1.4f, 0.41f, 0);
                    if (touchSc.animNum < 11)
                    {
                        touchSc.animNum++;
                        Camera.main.GetComponent<Animation>().Play(touchSc.animNum.ToString());
                    }
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    touchSc.sound.GetComponent<AudioSource>().PlayOneShot(touchSc.placeSound, 1);
                    touchSc.houseParticle.transform.position = transform.position;
                    touchSc.houseParticle.GetComponent<ParticleSystem>().Stop();
                    touchSc.houseParticle.GetComponent<ParticleSystem>().Play();
                    //GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ShowFullAds();

                }
            }

            else if (gameObject.tag == "yellow")
            {
                if (col.gameObject.tag == "yellow")
                {
                    for (int a = 0; a <= 2; a++)
                    {
                        touchSc.houseYellow[a].transform.GetChild(touchSc.housePlaceNum).GetComponent<SpriteRenderer>().sprite = col.GetComponent<SpriteRenderer>().sprite;
                    }

                    if (touchSc.animNum == 11)
                    {
                        col.gameObject.SetActive(false);
                        touchSc.sound.GetComponent<AudioSource>().PlayOneShot(touchSc.finish, 1);
                        touchSc.reBut.SetActive(true);
                        touchSc.homeBut.SetActive(true);
                        //GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ShowFullAds();
                    }
                    else
                    {
                        col.GetComponent<SpriteRenderer>().sprite = null;
                        col.transform.localPosition = new Vector3(-3.45f, 0.41f, 0);
                    }

                    if (touchSc.animNum < 11)
                    {
                        touchSc.animNum++;
                        Camera.main.GetComponent<Animation>().Play(touchSc.animNum.ToString());
                    }
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    touchSc.sound.GetComponent<AudioSource>().PlayOneShot(touchSc.placeSound, 1);
                    touchSc.houseParticle.transform.position = transform.position;
                    touchSc.houseParticle.GetComponent<ParticleSystem>().Stop();
                    touchSc.houseParticle.GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }
}
