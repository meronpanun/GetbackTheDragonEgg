using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class TitleDirector : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //A
        if (Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene("SaveScene");
            Debug.Log("ボタンが押された");
        }
        //B
        if (Input.GetKeyDown("joystick button 1"))
        {
            SceneManager.LoadScene("SaveScene");
        }
        //X
        if (Input.GetKeyDown("joystick button 2"))
        {
            SceneManager.LoadScene("SaveScene");
        }
        //Y
        if (Input.GetKeyDown("joystick button 3"))
        {
            SceneManager.LoadScene("SaveScene");
        }
        //LB
        if (Input.GetKeyDown("joystick button 4"))
        {
            SceneManager.LoadScene("SaveScene");
        }
        //RB
        if (Input.GetKeyDown("joystick button 5"))
        {
            SceneManager.LoadScene("SaveScene");
        }
        //BACK
        if (Input.GetKeyDown("joystick button 6"))
        {
            SceneManager.LoadScene("SaveScene");
        }

        //左スティック
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            //上に傾いている
            Debug.Log("ボタンが押された 1");
        }
        else if (0 < Input.GetAxisRaw("Vertical"))
        {
            //下に傾いている
            Debug.Log("ボタンが押された 2");
        }
        else
        {
            //上下方向には傾いていない
            Debug.Log("ボタンが押された 3");
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //左に傾いている
            Debug.Log("ボタンが押された 4");
        }
        else if (0 < Input.GetAxisRaw("Horizontal"))
        {
            //右に傾いている
            Debug.Log("ボタンが押された 5");
        }
        else
        {
            //左右方向には傾いていない
            Debug.Log("ボタンが押された 6");
        }

        ////右スティック
        //if (Input.GetAxisRaw("Vertical2") < 0)
        //{
        //    //上に傾いている
        //    Debug.Log("ボタンが押された");
        //}
        //else if (0 < Input.GetAxisRaw("Vertical2"))
        //{
        //    //下に傾いている
        //    Debug.Log("ボタンが押された");
        //}
        //else
        //{
        //    //上下方向には傾いていない
        //    Debug.Log("ボタンが押された");
        //}
        //if (Input.GetAxisRaw("Horizontal2") < 0)
        //{
        //    //左に傾いている
        //    Debug.Log("ボタンが押された");
        //}
        //else if (0 < Input.GetAxisRaw("Horizontal2"))
        //{
        //    //右に傾いている
        //    Debug.Log("ボタンが押された");
        //}
        //else
        //{
        //    //左右方向には傾いていない
        //    Debug.Log("ボタンが押された");
        //}

    }
}
