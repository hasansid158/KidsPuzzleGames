using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assigner4 : MonoBehaviour
{
    touchMove4 tSc;
    public Sprite[] imgs;
    List<Sprite> imgsList;
    int random;
    public Vector3[] sizes;
    List<Vector3> sizeList;
    int randSize;
    public int count, itemCount, countIn;

    void Start()
    {
        tSc = GetComponent<touchMove4>();
        imgsList = new List<Sprite>();
        sizes = new Vector3[3];
        sizeList = new List<Vector3>();

        sizes[0] = new Vector3(1.5f, 1.5f, 1.5f);
        sizes[1] = new Vector3(1.25f, 1.25f, 1.25f);
        sizes[2] = new Vector3(1.05f, 1.05f, 1.05f);

        for (int a = 0; a < imgs.Length; a++)
        {
            imgsList.Add(imgs[a]);
        }

        asigner();
    }

    public void asigner()
    {
        for (int b = 0; b < sizes.Length; b++)
        {
            sizeList.Add(sizes[b]);
            tSc.objs[b].transform.position = tSc.startPos[b];
            tSc.objs[b].transform.parent.GetComponent<Animation>().Play();
        }

        random = Random.Range(0, imgsList.Count);

        for (int b = 0; b < tSc.objs.Length; b++)
        {
            tSc.objs[b].GetComponent<SpriteRenderer>().sprite = imgsList[random];

            randSize = Random.Range(0, sizeList.Count);
            tSc.objs[b].transform.localScale = sizeList[randSize];
            sizeList.RemoveAt(randSize);
        }
        imgsList.RemoveAt(random);
    }
}
