using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Destroy(GameObject.Find("StageLoadSceneData"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
