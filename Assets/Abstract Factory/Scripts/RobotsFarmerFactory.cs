using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotsFarmerFactory : RobotsFactory
{
    private Transform _spawnPoint;

    public RobotsFarmerFactory(Transform spawnPoint)
    {
        
        _spawnPoint = spawnPoint;
    }

    public override GameObject CreateRobotT1()
    {
        var _farmerT1Prefab = Resources.Load<GameObject>("FarmerT1");
        var _farmerT1 = Instantiate(_farmerT1Prefab, _spawnPoint.position, Quaternion.identity);
        return _farmerT1;
    }

    public override GameObject CreateRobotT2()
    {
        var _farmerT2Prefab = Resources.Load<GameObject>("FarmerT2");
        var _farmerT2 = Instantiate(_farmerT2Prefab, _spawnPoint.position, Quaternion.identity);
        return _farmerT2;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
