using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrower : Tower
{

    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject potionPrefab;
    [SerializeField] private Transform PotionSpawnPoint;
    private GameObject newPotion;
    [SerializeField] private Animator _animator;
    private Rigidbody2D potionrb;


    private void Start()
    {
        potionrb = potionPrefab.GetComponent<Rigidbody2D>();

        if (potionrb == null)
        {
            Debug.LogError("Rigidbody2D not found");
            return;
        }

        potionrb.gravityScale = 0;

        StartCoroutine(RepeatAttacks(4f));
    }
    private IEnumerator RepeatAttacks(float delay)
    {
        while (true)
        {
            AttackEnemy();
            yield return new WaitForSeconds(delay);
        }
    }


    private void AttackEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _enemyLayer);

        if (enemies.Length > 0)
        {
            Collider2D targetEnemy = enemies[0];

            if (targetEnemy != null)
            {
                Debug.Log("ok");
                StartCoroutine(ThrowPotion(targetEnemy));
            }
        }
    }

    private IEnumerator ThrowPotion(Collider2D targetEnemy)
    {
        Debug.Log("Throwing potion at enemy: " + targetEnemy.name);

        // Calculate direction to the target enemy
        Vector2 direction = (targetEnemy.transform.position - transform.position).normalized;
        direction.y = 2f;

        // Set the gravity scale and apply force to throw the potion towards the target enemy
        float throwForce = 2.5f; // Adjust the throw force as needed
        potionrb.velocity = direction * throwForce * 3;
        potionrb.gravityScale = 2f;

        /*
        yield return new WaitForSeconds(1.5f);

        _animator.Play("PotionExplode");
        potionThrowFeedback.PlayFeedbacks();
        
        */
        yield return new WaitForSeconds(3f);

        newPotion = Instantiate(potionPrefab, PotionSpawnPoint.position, Quaternion.identity);
        potionrb = newPotion.GetComponent<Rigidbody2D>();
        potionrb.gravityScale = 0;
        potionrb.velocity = Vector2.zero;
        newPotion.transform.position = PotionSpawnPoint.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }


}
