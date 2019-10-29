using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Button[] buttons;
    public int index;

    bool canMove;

    void Start() {
        buttons[0].Select();
    }

    void Update()
    {
        float y = ControllerInput.GetJoystickLeftY();
        if (Mathf.Abs(y) > 0.1f)
        {
            if (!canMove) {
                if (y < 0.1f) {
                    if (index <= 0)
                    {
                        index++;
                    }
                    else {
                        index = 0;
                    }
                } else if (y > 0.1f) {
                    if (index > buttons.Length - 1)
                    {
                        index--;
                    }
                    else {
                        index = buttons.Length - 1;
                    }
                }
            }
            buttons[index].Select();
            canMove = true;
        }
        else {
            canMove = false;
        }
        if (ControllerInput.GetButtonA()) {
            switch (index)
            {
                case 0:
                    ScenesController.JumpScene(1);
                    break;

                case 1:
                    ScenesController.JumpScene(1);
                    break;

            }
        }
    }
}
