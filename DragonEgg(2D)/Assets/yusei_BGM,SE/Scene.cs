using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneChange1()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void SceneChange2()
    {
        SceneManager.LoadScene("CreditScene");
    }
    public void SceneChange3()
    {
        SceneManager.LoadScene("SoundScene");
    }  
    public void SceneChange4()
    {
        SceneManager.LoadScene("optionScene");
    }
}
