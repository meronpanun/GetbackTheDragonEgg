using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtunManager : MonoBehaviour
{
    private TestGenerator generator;
    // Start is called before the first frame update
    void Start()
    {
        generator = new TestGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EggButtun()
    {
        DragonDataManagerGenerater.dragonData.EggCreate();
        generator.PrepareDragonButtun();
    }
}
