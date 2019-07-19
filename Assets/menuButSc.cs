using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButSc : MonoBehaviour
{
    bool once;
    public GameObject fader;
    int lvlNum;

    public void playLevel(int inDex)
    {
        if (!once)
        {
            once = true;
            lvlNum = inDex;
            StartCoroutine(lvlWait());
        }
    }

    IEnumerator lvlWait()
    {
        fader.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(lvlNum);
    }

    public void moreApps()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=SQSAPPS");
    }
}
