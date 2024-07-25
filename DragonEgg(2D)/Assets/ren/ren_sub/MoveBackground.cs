using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public RectTransform background;
    public RectTransform background2;
    public RectTransform background3;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = background2.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(background.position.y < -800)
        {
            background.position = temp;
        }
        if (background2.position.y < -800)
        {
            background2.position = temp;
        }
        if (background3.position.y < -800)
        {
            background3.position = temp;
        }

        background.position -= new Vector3(0, 0.5f, 0);
        background2.position -= new Vector3(0, 0.5f, 0);
        background3.position -= new Vector3(0, 0.5f, 0);
    }
}
