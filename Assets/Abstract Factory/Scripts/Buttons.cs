using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Transform _workerSpawnPoint_1;
    [SerializeField] private Transform _farmerSpawnPoint_2;

    public void CreateWorkerT1() => new RobotsWorkerFactory(_workerSpawnPoint_1).CreateRobotT1();

    public void CreateWorkerT2() => new RobotsWorkerFactory(_workerSpawnPoint_1).CreateRobotT2();

    public void CreateFarmerT1() => new RobotsFarmerFactory(_farmerSpawnPoint_2).CreateRobotT1();

    public void CreateFarmerT2() => new RobotsFarmerFactory(_farmerSpawnPoint_2).CreateRobotT2();
}
