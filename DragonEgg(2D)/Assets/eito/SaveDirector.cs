using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene("HomeScene");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            SceneManager.LoadScene("HomeScene");
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            SceneManager.LoadScene("HomeScene");
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            SceneManager.LoadScene("HomeScene");
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            SceneManager.LoadScene("HomeScene");
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            SceneManager.LoadScene("HomeScene");
        }
        if (Input.GetKeyDown("joystick button 6"))
        {
            SceneManager.LoadScene("HomeScene");
        }
        Input.GetAxis("Horizontal");
       
        Input.GetAxis("Vertical");
        
    }
}
