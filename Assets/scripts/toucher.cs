using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toucher : MonoBehaviour
{
    public Sprite[] imgs;
    public GameObject[] charStop1, charStop2, charStop3;
    public GameObject[] houseGreen, housePurple, houseYellow;
    public GameObject[] ts;
    public GameObject[] trainColor;
    public GameObject cam;

    RaycastHit2D rayHit;
    bool move, once;

    public int placed, animNum;
    bool picked;

    public int tCharNum;
    public int housePlaceNum = -1;
    public int count;

    public GameObject houseParticle;
    public GameObject playBut, reBut, homeBut;
    public GameObject sound;
    public AudioClip placeSound, finish;

    int butNum;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!picked)
            {
                rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                picked = true;
            }

            for (int a = 0; a < charStop1.Length; a++)
            {
                if (!cam.GetComponent<Animation>().isPlaying)
                {
                    if (rayHit.collider == charStop1[a].GetComponent<BoxCollider2D>())
                    {
                        charStop1[a].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, charStop1[a].transform.position.z);
                    }
                    else if (rayHit.collider == charStop2[a].GetComponent<BoxCollider2D>())
                    {
                        charStop2[a].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, charStop1[a].transform.position.z);
                    }
                    else if (rayHit.collider == charStop3[a].GetComponent<BoxCollider2D>())
                    {
                        charStop3[a].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, charStop1[a].transform.position.z);
                    }
                }
            }
            if (!cam.GetComponent<Animation>().isPlaying && placed >= 3)
            {
                if (rayHit.collider == trainColor[0].GetComponent<BoxCollider2D>() && tCharNum == 1)
                {
                    trainColor[0].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, trainColor[0].transform.position.z);
                }
                if (rayHit.collider == trainColor[1].GetComponent<BoxCollider2D>() && tCharNum == 2)
                {
                    trainColor[1].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, trainColor[0].transform.position.z);
                }
                if (rayHit.collider == trainColor[2].GetComponent<BoxCollider2D>() && tCharNum == 3)
                {
                    trainColor[2].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, trainColor[0].transform.position.z);
                }
            }

        }
        else
        {
            picked = false;
        }

        if (placed == 3)
        {
            if (!once)
            {
                once = true;
                animNum = 1;
                cam.GetComponent<Animation>().Play(animNum.ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Play()
    {
        playBut.SetActive(false);
        cam.GetComponent<Animation>().Play();
        //GameObject.FindGameObjectWithTag("admob").GetComponent<admob>().ShowFullAds();
    }
}
