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
        if (cam.transform.position.y> 20)
        {
            StartCoroutine(FadeIn());

            Debug.Log("Test");
        }
        if (cam.transform.position.y > 25)
        {
            StartCoroutine(FadeOut());

            Debug.Log("Test2");
        }
    }
    IEnumerator FadeIn()
    {
        Transparency.alpha += 0.01f;
        yield return new WaitForSeconds(Time.deltaTime);
    }
    IEnumerator FadeOut()
    {
        Transparency.alpha -= 0.01f;
        yield return new WaitForSeconds(Time.deltaTime);
    }

}
