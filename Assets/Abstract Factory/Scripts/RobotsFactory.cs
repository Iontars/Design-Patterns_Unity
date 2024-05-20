using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RobotsFactory : MonoBehaviour
{
    public abstract GameObject CreateRobotT1();
    public abstract GameObject CreateRobotT2();
}
