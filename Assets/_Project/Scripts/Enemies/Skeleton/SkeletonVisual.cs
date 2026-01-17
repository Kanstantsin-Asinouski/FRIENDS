using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SkeletonVisual : MonoBehaviour
{
    [SerializeField] private EnemyAi _enemyAI;
    [SerializeField] private EnemyEntity _enemyEntity;

    private Animator _animator;

    private const string _IS_RUNNING = "IsRunning";
    private const string _CHASING_SPEED_MULTUPLIER = "ChasingSpeedMultiplier";
    private const string _ATTACK = "Attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _enemyAI.OnEnemyAttack += _enemyAI_OnEnemyAttack;
    }

    private void OnDestroy()
    {
        _enemyAI.OnEnemyAttack -= _enemyAI_OnEnemyAttack;
    }

    private void Update()
    {
        _animator.SetBool(_IS_RUNNING, _enemyAI.IsRunning);
        _animator.SetFloat(_CHASING_SPEED_MULTUPLIER, _enemyAI.GetRoamingAnimationSpeed);
    }

    public void TriggerAttackAnimationTurnOff()
    {
        _enemyEntity.AttackColliderTurnOff();
    }

    public void TriggerAttackAnimationTurnOn()
    {
        _enemyEntity.AttackColliderTurnOn();
    }

    private void _enemyAI_OnEnemyAttack(object sender, EventArgs e)
    {
        _animator.SetTrigger(_ATTACK); 
    }
}