using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{
    public GameObject menu;

    private void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
      
        if (!menu.activeInHierarchy)
        {
            if (ControllerInput.GetButtonRB() || ControllerInput.GetKeyE())
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
        else {
            if (ControllerInput.GetButtonRB() || ControllerInput.GetKeyE())
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
        }
       
    }
}
