using UnityEngine;
using UnityEngine.AI;
using Friends.Utils;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private State _startingState;
    [SerializeField] private float _roamingDistanceMax = 7f;
    [SerializeField] private float _roamingDistanceMin = 3f;
    [SerializeField] private float _roamingTimeMax = 2f;

    private NavMeshAgent _navMeshAgent;
    private State _state;
    private float _roamingTime;
    private Vector3 _roamPosition;
    private Vector3 _startingPosition;

    private enum State
    {
        Roaming
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _state = _startingState;

        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        switch (_state)
        {
            default:
            case State.Roaming:

                _roamingTime -= Time.deltaTime;

                if (_roamingTime < 0)
                {
                    Roaming();
                    _roamingTime = _roamingTimeMax;
                }

                break;
        }
    }

    private void Roaming()
    {
        _startingPosition = transform.position;
        _roamPosition = GetRoamingPosition();
        ChangeFacingDirection(_startingPosition, _roamPosition);
        _navMeshAgent.SetDestination(_roamPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return _startingPosition + FriendsUtils.GetRandomDir() * Random.Range(_roamingDistanceMin, _roamingDistanceMax);
    }

    private void ChangeFacingDirection(Vector3 sourcePosition, Vector3 targetPosition)
    {
        if (sourcePosition.x > targetPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}