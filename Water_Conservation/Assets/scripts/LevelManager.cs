using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Animator transitionAnim;

    public void lvl1()
    {
        StartCoroutine(loadScene());
        Application.LoadLevel(2);
    }

    public void lvl2()
    {
        StartCoroutine(loadScene());
        Application.LoadLevel(5);
    }
    IEnumerator loadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
    }
}
