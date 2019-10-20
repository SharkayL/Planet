using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoMovement : AllOGPhysics
{
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        accelaration =0f;
    }


    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        transform.position += -transform.right * accelaration * Time.deltaTime;
    //    }
    //}
}
