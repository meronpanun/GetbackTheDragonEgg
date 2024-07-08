using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtunManager : MonoBehaviour
{
    private DragonDataManager dragonData;
    private TestGenerator generator;
    // Start is called before the first frame update
    void Start()
    {
        dragonData = new DragonDataManager();
        generator = new TestGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EggButtun()
    {
        dragonData.EggCreate();
        generator.PrepareDragonButtun();
    }
}
