using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveData : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public const int rankCnt = 3;
        public int[] rank = new int[rankCnt];
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
