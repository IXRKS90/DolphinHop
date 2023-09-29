using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Character;

    private void Update()
    {
        Camera.main.transform.position = new Vector3(Character.position.x, transform.position.y, transform.position.z);

        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    Camera.main.orthographicSize = 4;
        //}
        //else if (Input.GetKeyUp(KeyCode.Mouse0))
        //{
        //    Camera.main.orthographicSize = 6;
        //}
    }
}
