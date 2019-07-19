using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public GameObject fader, but1, but2;
    bool once;

    public void goHome()
    {
        if (!once)
        {
            once = true;
            but1.SetActive(false);
            but2.SetActive(false);
            StartCoroutine(homeWait());
        }
    }

    IEnumerator homeWait()
    {
        fader.GetComponent<Animation>().Play("fadeIn");
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(0);
    }

    public void rePlay()
    {
        but1.SetActive(false);
        but2.SetActive(false);
        StartCoroutine(reWait());
    }

    IEnumerator reWait()
    {
        fader.GetComponent<Animation>().Play("fadeIn");
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
