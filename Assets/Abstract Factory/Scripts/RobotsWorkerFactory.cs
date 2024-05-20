using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotsWorkerFactory : RobotsFactory
{
    private Transform _spawnPoint;

    public RobotsWorkerFactory(Transform spawnPoint)
    {

        _spawnPoint = spawnPoint;
    }

    public override GameObject CreateRobotT1()
    {
        var _workerT1Prefab = Resources.Load<GameObject>("WorkerT1");
        var _workerT1 = Instantiate(_workerT1Prefab, _spawnPoint.position, Quaternion.identity);
        return _workerT1;
    }

    public override GameObject CreateRobotT2()
    {
        var _workerT2Prefab = Resources.Load<GameObject>("WorkerT2");
        var _workerT2 = Instantiate(_workerT2Prefab, _spawnPoint.position, Quaternion.identity);
        return _workerT2;
    }
}
