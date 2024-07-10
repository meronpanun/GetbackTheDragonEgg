using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDataManagerGenerater : MonoBehaviour
{
    public static DragonDataManager dragonData;
    // Start is called before the first frame update
    void Start()
    {
        // Static‚ÌDragondataManager‚ğì¬
        dragonData = new DragonDataManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
