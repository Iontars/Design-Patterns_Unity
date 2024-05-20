using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Memory : MonoBehaviour
{
    private Camera mainCamera;
    public List<Vector3> checkPionts = new();

    //public event Action StartMoving;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                checkPionts.Add(hit.point);
                
            }
        }
    }
}
