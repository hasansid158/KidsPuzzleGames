using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assigner2 : MonoBehaviour
{
    public Sprite[] blackImg, imgs;
    touchMove2 scripts;
    public GameObject vanImg;

    List<Sprite> imageList;
    public List<Sprite> imgGroundList;

    int random;
    public int imgNum;
    int rands;
    public int slctNum;

    public GameObject hand;

    bool moveHand;
    public bool pressed;
    public int adTime;

    void Start()
    {
        scripts = GetComponent<touchMove2>();
        imageList = new List<Sprite>();
        imgGroundList = new List<Sprite>();

        assign();
    }

    public void assign()
    {
        pressed = false;
        //Assign Van
        if (imageList.Count <= 0)
        {
            for (int a = 0; a < blackImg.Length; a++)
            {
                imageList.Add(blackImg[a]);
            }
        }
        if (imageList.Count > 2)
        {
            random = Random.Range(0, imageList.Count);

            vanImg.GetComponent<SpriteRenderer>().sprite = imageList[random];
            imageList.RemoveAt(random);
        }
        else
        {
            vanImg.GetComponent<SpriteRenderer>().sprite = imageList[0];
            imageList.RemoveAt(0);
        }

        //Assign ground veg
        for (int z = 0; z < imgs.Length; z++)
        {
            if (vanImg.GetComponent<SpriteRenderer>().sprite == blackImg[z])
            {
                imgNum = z;
            }
        }

        imgGroundList.Clear();
        scripts.GetComponent<touchMove2>().nameList.Clear();
        for (int x = 0; x < imgs.Length; x++)
        {
            imgGroundList.Add(imgs[x]);
            scripts.GetComponent<touchMove2>().nameList.Add(scripts.GetComponent<touchMove2>().names[x]);
        }

        imgGroundList.RemoveAt(imgNum);

        for (int b = 0; b < scripts.groundVeg.Length; b++)
        {
            rands = Random.Range(0, imgGroundList.Count);
            scripts.groundVeg[b].GetComponent<SpriteRenderer>().sprite = imgGroundList[rands];
            scripts.groundVeg[b].GetComponent<Animation>().Play();
            imgGroundList.RemoveAt(rands);
        }

        slctNum = Random.Range(0, scripts.groundVeg.Length);
        scripts.groundVeg[slctNum].GetComponent<SpriteRenderer>().sprite = imgs[imgNum];
        StopAllCoroutines();
        StartCoroutine(handWait());
    }

    void Update()
    {
        if (moveHand && !pressed)
        {
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, vanImg.transform.position, 4.5f * Time.deltaTime);
        }

        if (pressed)
        {
            hand.SetActive(false);
            StopCoroutine("handWait");
        }
    }

    public void handCoStarter()
    {
        StopCoroutine("handWait");
        StartCoroutine("handWait");
    }

    public void handStopper()
    {
        StopCoroutine("handWait");
        hand.SetActive(false);
    }

    public IEnumerator handWait()
    {
        if (!pressed)
        {
            yield return new WaitForSeconds(3f);
            for (int a = 0; a < imgs.Length; a++)
            {
                if(vanImg.GetComponent<SpriteRenderer>().sprite == blackImg[a])
                {
                    slctNum = a;
                }
            }
            for(int b = 0; b< scripts.groundVeg.Length; b++)
            {
                if (scripts.groundVeg[b].GetComponent<SpriteRenderer>().sprite == imgs[slctNum])
                {
                    hand.transform.position = scripts.groundVeg[b].transform.position;
                }
            }
            if (!pressed)
            {
                hand.SetActive(true);
            }
            moveHand = true;
            yield return new WaitForSeconds(1.6f);
            hand.SetActive(false);
            StartCoroutine(handWait());
        }
    }
}
