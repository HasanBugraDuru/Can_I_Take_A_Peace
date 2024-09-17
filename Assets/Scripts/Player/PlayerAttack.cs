using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmount = 1f;
    [HideInInspector] public bool CanHit;
    Animator anim;
    private RaycastHit2D[] hits;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(CanHit)
        {
            if (UserInput.instance.controls.Attack.Attack.WasPressedThisFrame())
            {
                Attack();
                anim.SetTrigger("Attack");
            }   
        }
        
    }

    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position,
            attackRange, transform.right, 0f, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable damageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

            // if there is a damageable object

            if(damageable != null)
            {
                //Apple damage 
                damageable.Damage(damageAmount);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position,attackRange);
    }
}
