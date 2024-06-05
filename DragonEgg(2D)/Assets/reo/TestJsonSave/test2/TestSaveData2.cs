using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveData2 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

namespace App.SaveSystem
{
    [System.Serializable]
    public class SaveData
    {
        public int MaxScore
        {
            get => maxScore;
            set => maxScore = value;
        }
        public int maxScore; // ŠO•”‚ÅQÆ‚³‚¹‚È‚¢
    }
}