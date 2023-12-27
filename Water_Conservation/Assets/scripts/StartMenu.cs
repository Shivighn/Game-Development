using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject Canvas;

    private bool Startmenu = true;

    public Animator transitionAnim;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(true);
    }
    public void play()
    {
        StartCoroutine(loadScene());
        Application.LoadLevel(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator loadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
    }

}
