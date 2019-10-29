using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeRealKangAroo : MonoBehaviour
{

    public enum KangArooType {
        fake,
        real,
        Player
    }

    public KangArooType type;
    public GameObject detectArea;

    void Update()
    {
        kangArooState();
    }

    void kangArooState() {
        switch (type) {
            case KangArooType.fake:
                gameObject.layer = 0;
                detectArea.SetActive(false);
                break;
            case KangArooType.real:
                gameObject.layer = 9;
                detectArea.SetActive(true);
                if (GetComponent<PlayerMovementScript>().enabled) {
                    GetComponent<ExperimentHopping>().enabled = false;
                    GetComponent<PlayerGravityBody>().enabled = true;
                    type = KangArooType.Player;
                }
                break;
            case KangArooType.Player:
                gameObject.layer = 10;
                detectArea.SetActive(false);
                if (!GetComponent<PlayerMovementScript>().enabled)
                {
                    GetComponent<ExperimentHopping>().enabled = true;
                    GetComponent<PlayerGravityBody>().enabled = false;
                    type = KangArooType.real;
                }
                break;
        }
    }
}
