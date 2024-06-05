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
        Input.GetAxis("Horizontal");
       
        Input.GetAxis("Vertical");
        
    }
}
