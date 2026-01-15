using UnityEngine;

public class SwordVisual : MonoBehaviour
{
    [SerializeField] private Sword _sword;
    private Animator _animator;
    private const string _ATTACK = "Attack";

    public void TriggerEndAttackAnimation()
    {
        _sword.AttackColliderTurnOff();
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _sword.OnSwordSwing += Sword_OnSwordSwing;
    }

    private void Sword_OnSwordSwing(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(_ATTACK);
    }    
}