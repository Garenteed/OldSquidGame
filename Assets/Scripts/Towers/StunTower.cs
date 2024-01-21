using System.Collections;
using MoreMountains.Feedbacks;
using System.Collections.Generic;
using UnityEngine;

public class StunTower : Tower
{
    [SerializeField] private float _attackRadius = 10f;
    [SerializeField] private Sprite stunSprite;
    [SerializeField] private Sprite unstunSprite;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private MMFeedbacks sound;
    void Start()
    {
        sprite.sprite = unstunSprite;
        StartCoroutine(RepeatStuns(5f));

    }

    // Update is called once per frame
    void Update()
    {


    }
    private IEnumerator RepeatStuns(float delay)
    {
        while (true)
        {
            StartCoroutine(StunEnemy());
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator StunEnemy()
    {
        Collider2D[] enemiesToStun = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _enemyLayer);

        foreach (Collider2D enemyCollider in enemiesToStun)
        {
            Enemy enemy = enemyCollider.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                Debug.Log("stunned");
                for (int i = 0; i <= 5; i++)
                {
                    sprite.sprite = stunSprite;
                    enemy.GetStunned();
                    sound.PlayFeedbacks();

                }
            }
        }

        yield return new WaitForSeconds(2f);

        Collider2D[] enemiesStunned = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _enemyLayer);

        foreach (Collider2D enemyCollider in enemiesStunned)
        {
            Enemy enemy = enemyCollider.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                sprite.sprite = unstunSprite;
                Debug.Log("unstunned");
                enemy.RemoveStun();
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
