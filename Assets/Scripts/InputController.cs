using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject cube;
    
	private void Update ()
    {
        foreach (var touch in Input.touches)
        {
            Shoot(touch.position);
            if (Input.touchCount > 1 && touch.phase == TouchPhase.Began)
            {
                AddCube();
            }
        }
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Shoot(Input.mousePosition);
        //    AddCube();
        //}
    }

    private void AddCube()
    {
        GameObject.Instantiate(cube, this.transform.position + transform.forward * 0.3f, Random.rotation);
    }

    private void Shoot(Vector2 screenPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            hitInfo.rigidbody.AddForceAtPosition(ray.direction, hitInfo.point);
        }
    }
}
