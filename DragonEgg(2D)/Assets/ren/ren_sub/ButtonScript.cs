using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{
    EventSystem eventSystem;
    public GameObject goButton;
    // Start is called before the first frame update
    void Start()
    {
       eventSystem = EventSystem.current;
       eventSystem.SetSelectedGameObject(goButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
