using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warningManager : MonoBehaviour
{
    Image fadeImage;
    float time = 0.0f;
    float fedeSpeed = 1.0f;
    CanvasGroup Transparency;
    bool isFadewarning = false;
    float fadeStart = 24f;
    float fadeEnd = 0.3f;

    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        Transparency = GetComponent<CanvasGroup>();
        fadeImage = GetComponent<Image>();
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cam.transform.position.y> fadeStart && cam.transform.position.y < fadeStart + fadeEnd)
        {
            StartCoroutine(FadeIn());

            Debug.Log("Test");
        }
        else if (cam.transform.position.y > fadeStart + fadeEnd && cam.transform.position.y < fadeStart + fadeEnd*2 )
        {
            StartCoroutine(FadeOut());

            Debug.Log("Test2");
        }
        else if (cam.transform.position.y> fadeStart + fadeEnd *2 && cam.transform.position.y < fadeStart + fadeEnd*3)
        {
            StartCoroutine(FadeIn());

            Debug.Log("Test1");
        }
        else if (cam.transform.position.y > fadeStart + fadeEnd * 3)
        {
            StartCoroutine(FadeOut());

            Debug.Log("Test2");
        }
    }
    IEnumerator FadeIn()
    {
        Transparency.alpha += 0.03f;
        yield return new WaitForSeconds(Time.deltaTime);
    }
    IEnumerator FadeOut()
    {
        Transparency.alpha -= 0.03f;
        yield return new WaitForSeconds(Time.deltaTime);
    }

}
