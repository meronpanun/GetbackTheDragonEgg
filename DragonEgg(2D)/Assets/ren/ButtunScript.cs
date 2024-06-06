using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtunScript : MonoBehaviour
{
    public GameObject camera;

    // ボタンが押された場合、今回呼び出される関数
   
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("CameraController");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
        BootsupandsquadManager.CameraMove1();
    }
}
