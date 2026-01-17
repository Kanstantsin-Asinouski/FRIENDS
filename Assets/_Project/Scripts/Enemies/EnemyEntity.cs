using UnityEngine;

[RequireComponent (typeof(PolygonCollider2D))]
public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Attack");
    }

    public void AttackColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }

    public void AttackColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }    

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        DetectDeath();
    }

    private void DetectDeath()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void AttackColliderTurnOffOn()
    {
        AttackColliderTurnOff();
        AttackColliderTurnOn();
    }
}