using UnityEngine;
using UnityEngine.AI;
using Friends.Utils;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimeMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamPosition;
    private Vector3 startingPosition;

    private enum State
    {
        Idle,
        Roaming
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        state = startingState;

        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Idle:
                break;
            case State.Roaming:

                roamingTime -= Time.deltaTime;

                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = roamingTimeMax;
                }

                break;
        }
    }

    private void Roaming()
    {
        roamPosition = GetRoamingPosition();
        navMeshAgent.SetDestination(roamPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + FriendsUtils.GetRandomDir() * Random.Range(roamingDistanceMin, roamingDistanceMax);
    }
}