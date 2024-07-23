using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectManager : MonoBehaviour
{
    private int maxDragonNum = 4;
    public GameObject managerMember1;
    public GameObject managerMember2;
    // Start is called before the first frame update
    void Start()
    {
        managerMember1.SetActive(true);
        managerMember2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectDragonManager.selectDragonNum++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectDragonManager.selectDragonNum--;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecisionMember();
        }

        if (SelectDragonManager.selectDragonNum >= maxDragonNum)
        {
            SelectDragonManager.selectDragonNum = 0;
        }
        if (SelectDragonManager.selectDragonNum < 0)
        {
            SelectDragonManager.selectDragonNum = maxDragonNum - 1;
        }


    }

    void DecisionMember()
    {
        managerMember1.SetActive(false);
        managerMember2.SetActive(true);
    }
}
