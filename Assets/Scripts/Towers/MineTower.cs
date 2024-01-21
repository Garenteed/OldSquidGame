using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTower : Tower
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private MMFeedbacks sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Explode();
            GettingAttacked(100000000);
        }
    }

    private void Explode()
    {
        sound.PlayFeedbacks();
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _enemyLayer);

        foreach (Collider2D enemyCollider in enemies)
        {
            Enemy enemy = enemyCollider.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                _animator.Play("ded");
                enemy._stunned = true;
                enemy.TakeDamage(100000);
            }

        }

        


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
