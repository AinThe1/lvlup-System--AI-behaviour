using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private GameObject[] _movePoints;
    private PlayerStages _player;
    [Header("Stats")]
    [SerializeField] private float _waitTime = 4f;
    [SerializeField] private float _lookRadius = 5f;
    [SerializeField] private int _stage;
    public int Stage { get => _stage; }

    private NavMeshAgent _agent;
    private int _randomPoints;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerStages>();
        StartCoroutine(RandomPoint());
    }


    private void Update() => EnemyBehavior();
    

    private IEnumerator RandomPoint() 
    {
        while (true) 
        {
            _randomPoints = Random.Range(0, _movePoints.Length);
            _agent.destination = _movePoints[_randomPoints].transform.position;
            yield return new WaitForSeconds(_waitTime);
        }
    }


    private void EnemyBehavior()
    {       
        var Distance = Vector3.Distance(_player.transform.position, transform.position); 
        var PositionPlayer = (transform.position - _player.transform.position).normalized;
        PositionPlayer = Quaternion.AngleAxis(45, Vector3.up) * PositionPlayer;
        
        if (Distance <= _lookRadius)
        {
           if(_stage > _player.Stage)
               _agent.destination = _player.transform.position;      
           else
               _agent.destination = transform.position + PositionPlayer;
        }
    }
}
