using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Button[] buttons;
    public int index;
    public GameObject howToPlayPanel;

    bool canMove;

    void Start() {
        buttons[0].Select();
        howToPlayPanel.SetActive(false);
    }

    public void nextScene() {
        ScenesController.JumpScene(1);
    }

    public void QuitGame() {
        ScenesController.ExitGame();
    }

    void Update()
    {
        float y = ControllerInput.GetJoystickLeftY();
        Debug.Log(y);
        if (ControllerInput.GetButtonB()) {
            howToPlayPanel.SetActive(false);
        }
        if (Mathf.Abs(y) > 0.2f)
        {
            if (!canMove) {
                if (y < -0.2f) {
                    if (index <= 0)
                    {
                        index = 0;
                    }
                    else
                    {
                        index--;
                    }
                } else if (y > 0.2f) {
                    if (index > buttons.Length - 1)
                    {
                        index = buttons.Length - 1;
                    }
                    else
                    {
                        index++;
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
                    howToPlayPanel.SetActive(true);
                    break;
                case 2:
                    ScenesController.ExitGame();
                    break;

            }
        }
    }
}
