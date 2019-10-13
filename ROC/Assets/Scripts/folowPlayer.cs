using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowPlayer : MonoBehaviour
{

   private Vector3 posCamera;

    // Update is called once per frame
    void Update()
    {
      posCamera = GameObject.Find("Hero").GetComponent<Transform>().position;
      posCamera.z = -5;
      GetComponent<Transform>().position = posCamera;
    }
}
