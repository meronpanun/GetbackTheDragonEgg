using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour
{
    private GameObject creditObj;
    private float addPosY = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        creditObj = GameObject.Find("Canvas/CreditText");
    }

    // Update is called once per frame
    void Update()
    {
        creditObj.transform.position += new Vector3(0, addPosY, 0);
    }
}
