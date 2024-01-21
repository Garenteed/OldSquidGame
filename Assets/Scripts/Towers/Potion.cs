using System.Collections;
using MoreMountains.Feedbacks;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private Animator _animator;
    [SerializeField] private MMFeedbacks potionThrowFeedback;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.Play("PotionExplosion");
        potionThrowFeedback.PlayFeedbacks();
        int layerToCheck = collision.gameObject.layer;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _enemyLayer);

            foreach (Collider2D enemyCollider in enemies)
            {
                Enemy enemy = enemyCollider.gameObject.GetComponent<Enemy>();

                if (enemy != null)
                {

                    enemy.TakeDamage(500);
                }

            }
        Destroy(gameObject);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
