using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test1 : MonoBehaviour
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
        SceneManager.LoadScene("LevelUpScene");
    }
    public void SceneChange3()
    {
        SceneManager.LoadScene("SaveScene");
    }
}

