using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent agent;
    public Memory memory;

    Vector3 startPosition;

    private void Awake()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }
    void Start()
    {
        
    }

    private void Go()
    {
        agent.SetDestination(memory.checkPionts[0]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Go();
        }

        //if (Input.GetMouseButton(0))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
        //    {
        //        agent.SetDestination(hit.point);
        //    }
        //}
        //else if (Input.GetMouseButton(1))
        //{
        //    agent.SetDestination(startPosition);
        //}
    }

    //private void OnEnable() => memory.StartMoving += Go;
    //private void OnDisable() => memory.StartMoving -= Go;
}
