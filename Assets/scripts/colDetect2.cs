using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colDetect2 : MonoBehaviour
{
    public GameObject scripts;
    touchMove2 touchSc;
    assigner2 asignSc;
    public GameObject vegIn, van;
    public GameObject colorPart;
    public AudioClip truckSound, placeSound;
    int vegNum;
    public int rand;

    List<GameObject> vegDownList;
    public GameObject smallPart;
    int tNum;
    public GameObject butAgain, butHome;

    void Start()
    {
        vegDownList = new List<GameObject>();
        touchSc = scripts.GetComponent<touchMove2>();
        asignSc = scripts.GetComponent<assigner2>();
        scripts.GetComponent<AudioSource>().PlayOneShot(truckSound, 0.8f);

        for (int b = 0; b < touchSc.groundVeg.Length; b++)
        {
            vegDownList.Add(touchSc.groundVeg[b]);
        }
        rand = Random.Range(0, vegDownList.Count);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        for (int a = 0; a < asignSc.blackImg.Length; a++)
        {
            if (GetComponent<SpriteRenderer>().sprite == asignSc.blackImg[a])
            {
                if (col.GetComponent<SpriteRenderer>().sprite == asignSc.imgs[a])
                {
                    scripts.GetComponent<AudioSource>().PlayOneShot(placeSound, 1);
                    col.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().sprite = null;
                    vegIn.GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                    col.gameObject.GetComponent<SpriteRenderer>().sprite = null;
                    vegIn.GetComponent<Animation>().Play();
                    if (vegNum >= 4)
                    {
                        vegDownList.Clear();
                        van.GetComponent<Animation>().Play("vanOut");
                        StartCoroutine(animWait());
                        scripts.GetComponent<AudioSource>().Play();
                        vegNum = 0;

                        for (int b = 0; b < touchSc.groundVeg.Length; b++)
                        {
                            vegDownList.Add(touchSc.groundVeg[b]);
                        }
                    }
                    else
                    {
                        asignSc.pressed = false;
                        asignSc.GetComponent<assigner2>().handCoStarter();

                        vegNum++;
                        for (int c = 0; c < vegDownList.Count; c++)
                        {
                            if (vegDownList[c].GetComponent<SpriteRenderer>().sprite == null)
                            {
                                vegDownList.RemoveAt(c);
                            }
                        }
                        rand = Random.Range(0, vegDownList.Count);
                        asignSc.slctNum = rand;

                        GetComponent<Animation>().Play();
                        for (int x = 0; x < asignSc.blackImg.Length; x++)
                        {
                            if (vegDownList[rand].GetComponent<SpriteRenderer>().sprite == asignSc.imgs[x])
                            {
                                GetComponent<SpriteRenderer>().sprite = asignSc.blackImg[x];
                            }
                        }
                    }
                    if (asignSc.adTime > 2)
                    {
                        //GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ShowFullAds();
                        asignSc.adTime = 0;
                    }
                    else
                    {
                        asignSc.adTime++;
                    }
                    smallPart.GetComponent<ParticleSystem>().Play();
                    asignSc.handStopper();
                }
            }
        }
    }

    void Update()
    {
        if (asignSc.adTime > 2)
        {
            asignSc.GetComponent<assigner2>().handStopper();
        }
    }

    IEnumerator animWait()
    {
        yield return new WaitForSeconds(0.6f);
        scripts.GetComponent<AudioSource>().PlayOneShot(truckSound, 0.8f);
        colorPart.GetComponent<ParticleSystem>().Play();
        if (asignSc.adTime > 2)
        {
            butAgain.SetActive(true);
            butHome.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(2f);
            scripts.GetComponent<AudioSource>().PlayOneShot(truckSound, 0.8f);
            van.GetComponent<Animation>().Play();
            asignSc.assign();
        }
        Debug.Log(asignSc.adTime);

    }
}
