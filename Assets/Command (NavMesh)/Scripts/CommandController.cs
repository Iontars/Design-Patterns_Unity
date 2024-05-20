using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class CommandController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Queue<Command> _commands = new Queue<Command>();
    private Command _currentCommand;
    public GameObject touchRing;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void ProcessCommand()
    {
        if (_currentCommand != null && _currentCommand.IsFinished == false)
        {
            return;
        }
        else if (_commands.Any() == false)
        {
            return;
        }

        _currentCommand = _commands.Dequeue();
        _currentCommand.Execute();
    }

    private void ListenForCommands()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                MoveCommand moveCommand = new MoveCommand(hit.point, _agent);
                _commands.Enqueue(moveCommand);
                
                //GameObject tempPS = Instantiate(touchRing, hit.point, Quaternion.identity);
                Destroy(Instantiate(touchRing, hit.point, Quaternion.identity), 3f);
            }
        }

    }

    internal class MoveCommand : Command
    {
        private readonly Vector3 _destination;
        private readonly NavMeshAgent _agent;

        public MoveCommand(Vector3 _destination, NavMeshAgent _agent)
        {
            this._destination = _destination;
            this._agent = _agent;
        }

        public override void Execute()
        {
            _agent.SetDestination(_destination);
        }

        public override bool IsFinished => _agent.remainingDistance <= 0.1f;

    }

    void Update()
    {
        ListenForCommands();
        ProcessCommand();
    }
}
