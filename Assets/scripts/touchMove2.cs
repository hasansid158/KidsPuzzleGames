using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchMove2 : MonoBehaviour
{
    public GameObject[] groundVeg;
    Vector3[] vegPos;
    Vector3[] touchPos;

    RaycastHit2D hits;
    int ind;
    float moveSpeed;

    bool touched;

    public AudioClip[] names;
    public List<AudioClip> nameList;

    void Start()
    {
        vegPos = new Vector3[groundVeg.Length];
        touchPos = new Vector3[groundVeg.Length];
        nameList = new List<AudioClip>();

        for (int a = 0; a < groundVeg.Length; a++)
        {
            vegPos[a] = groundVeg[a].transform.position;
            touchPos[a] = groundVeg[a].transform.position;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hits = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);

            for (int a = 0; a < groundVeg.Length; a++)
            {
                groundVeg[a].GetComponent<SpriteRenderer>().sortingOrder = 5;

                if (hits.collider == groundVeg[a].GetComponent<CircleCollider2D>())
                {
                    ind = a;
                    groundVeg[a].GetComponent<SpriteRenderer>().sortingOrder = 6;
                    touched = true;
                    moveSpeed = 20;

                    if (groundVeg[a].GetComponent<SpriteRenderer>().sprite == GetComponent<assigner2>().imgs[GetComponent<assigner2>().slctNum])
                    {
                        GetComponent<assigner2>().pressed = true;
                        GetComponent<assigner2>().handStopper();
                        GetComponent<assigner2>().hand.SetActive(false);
                    }

                    for (int b = 0; b < GetComponent<assigner2>().imgs.Length; b++)
                    {
                        for (int c = 0; c < GetComponent<assigner2>().imgGroundList.Count; c++)
                        {
                            if (hits.collider.GetComponent<SpriteRenderer>().sprite == GetComponent<assigner2>().imgs[b])
                            {
                                GetComponent<AudioSource>().Stop();
                                GetComponent<AudioSource>().PlayOneShot(names[b], 1);
                            }
                        }
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touched = false;
            GetComponent<assigner2>().pressed = false;
            moveSpeed = 2.5f;
            touchPos[ind] = vegPos[ind];
        }

        if (touched)
        {
            touchPos[ind] = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }

        for (int a = 0; a < groundVeg.Length; a++)
        {
            groundVeg[a].transform.position = Vector3.Slerp(groundVeg[a].transform.position, touchPos[a], moveSpeed * Time.deltaTime);
        }
    }
}
