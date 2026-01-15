using UnityEngine;

public class SkeletonVisual : MonoBehaviour
{
    [SerializeField] private EnemyAi _enemyAI;

    private Animator _animator;

    private const string _IS_RUNNING = "IsRunning";
    private const string _CHASING_SPEED_MULTUPLIER = "ChasingSpeedMultiplier";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(_IS_RUNNING, _enemyAI.IsRunning);
        _animator.SetFloat(_CHASING_SPEED_MULTUPLIER, _enemyAI.GetRoamingAnimationSpeed);
    }
}