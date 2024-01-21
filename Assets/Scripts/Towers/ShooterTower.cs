using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShooterTower : Tower
{
    [Header("ShooterTowerSetting")]

    [SerializeField] private Transform _shooterPoint;
    [SerializeField] private ShooterBullet _projectile;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private LayerMask _raycastLayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private MMFeedbacks sound;

    private float _attackTime;
    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        _attackTime += Time.deltaTime;
        if(_attackTime > _attackCooldown)
        {
            _attackTime = 0f;
            AttackEnemy();
            
        }
        
 
    }


    private void AttackEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_shooterPoint.position, _attackRadius, _enemyLayer);

        Collider2D[] closestEnemies = enemies.OrderBy(enemy => (_shooterPoint.position - enemy.transform.position).sqrMagnitude).ToArray();

        
        foreach (Collider2D enemy in closestEnemies)
        {

            RaycastHit2D hit = Physics2D.Raycast(_shooterPoint.position, enemy.transform.position - _shooterPoint.position , _attackRadius, _raycastLayer);
            if (hit.collider != null)
            {
                
                if(hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy enemyHit))
                {
                    ShooterBullet newBullet = Instantiate(_projectile);
                    newBullet.transform.position = _shooterPoint.position;
                    newBullet.FireAtTransform(enemyHit.transform, _shooterPoint);
                    _animator.Play("Shooter_Attack");
                    sound.PlayFeedbacks();
                    if(enemyHit.transform.position.x > _shooterPoint.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                    if (enemyHit.transform.position.x < _shooterPoint.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0,180, 0);
                    }
                        break ;
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_shooterPoint.position, _attackRadius);


    }


}
