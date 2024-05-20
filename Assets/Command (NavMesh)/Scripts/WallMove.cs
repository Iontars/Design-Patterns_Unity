using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public GameObject wall;
    Vector3 leftPosition;
    Vector3 rightPosition;
    private float speed = 2f;
    private float wallOffset = 6;
    private int direction = 1;

    void Start()
    {
        leftPosition = new Vector3(transform.position.x + wallOffset, transform.position.y, transform.position.z);
        rightPosition = new Vector3(transform.position.x - wallOffset, transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * direction * Time.deltaTime);

        if (transform.position.x >= leftPosition.x)
        {
            direction = 1;
        }
        else if (transform.position.x <= rightPosition.x)
        {
            direction = -1;
        }
    }
}
