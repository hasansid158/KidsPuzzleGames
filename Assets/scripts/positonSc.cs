using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positonSc : MonoBehaviour
{
    Vector3 startPos;
    public float xPos;

    void Awake()
    {
        startPos = transform.position;
        setPos();
    }

    public void setPos()
    {
        transform.position = startPos;
        float height = transform.localScale.y * 100;
        float width = transform.localScale.x * 100;

        float w = Screen.width / width;
        float h = Screen.height / height;

        float ratio = w / h;

        float size = (height / 2) / 100f;

        if (w < h)
            size /= ratio;

        Vector2 position = transform.position;

        Vector3 camPosition = position;
        Vector3 point = Camera.main.WorldToViewportPoint(camPosition);
        Vector3 delta = camPosition - Camera.main.ViewportToWorldPoint(new Vector3(xPos, 0.5f, point.z));
        Vector3 destination = transform.position + delta;

        transform.position = destination;
    }
}
