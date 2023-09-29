using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEA : MonoBehaviour
{
    private BuoyancyEffector2D sea;


    private void Start()
    {
        sea = GetComponentInChildren<BuoyancyEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            sea.density = 0;
            sea.linearDrag = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            sea.density = 5;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dolphin"))
        {
            this.GetComponentInChildren<BuoyancyEffector2D>().linearDrag = 25;
            //this.GetComponentInChildren<BuoyancyEffector2D>().density = 5;
            Debug.Log("In water");
        }
    }
}
