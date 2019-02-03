using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	
	void Update ()
    {
        this.transform.Rotate(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0);
	}
}
