using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assigner3 : MonoBehaviour
{
    touchMove3 tSc;
    public GameObject darkShape;

    public Sprite[] shapeImgs, darkImgs;
    List<Sprite> shapeList;
    int randNum;

    public void asginNow()
    {
        tSc = GetComponent<touchMove3>();
        shapeList = new List<Sprite>();
        assign();

        for (int a = 0; a < shapeImgs.Length; a++)
        {
            shapeList.Add(darkImgs[a]);
        }
        darkAsign();
    }

    void assign()
    {
        shapeList.Clear();

        for (int a = 0; a < shapeImgs.Length; a++)
        {
            shapeList.Add(shapeImgs[a]);
        }

        for (int x = 0; x < shapeImgs.Length; x++)
        {
            randNum = Random.Range(0, shapeList.Count);
            tSc.shapes[x].GetComponent<SpriteRenderer>().sprite = shapeList[randNum];
            shapeList.RemoveAt(randNum);
        }
    }

    public void darkAsign()
    {
        randNum = Random.Range(0, shapeList.Count);
        darkShape.GetComponent<Animation>().Play();
        darkShape.GetComponent<SpriteRenderer>().sprite = shapeList[randNum];
        shapeList.RemoveAt(randNum);
    }
}
