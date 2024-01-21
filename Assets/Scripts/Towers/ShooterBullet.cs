using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBullet : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _projectileDamage;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private MMFeedbacks sound;

    private void Start()
    {
        float objectTime = 10f;
        Destroy(gameObject, objectTime);
    }

    public void AttackUp()
    {
        _rb.AddForce(Vector2.up * 1000);
    }
    public void FireAtTransform(Transform target, Transform startLocation)
    {
        Vector3 fireDirection = (target.position - startLocation.position  ).normalized;
        
        //make the bullet point toward the target
        float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        float flipY = 0;
        if (angle > 180)
        {
            angle -= 180;
            flipY = 180;
        }

        transform.rotation = Quaternion.Euler(0, flipY, angle);
        
        

        _rb.AddForce(fireDirection * _projectileSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_projectileDamage);
            sound.PlayFeedbacks();
            Destroy(gameObject,0.1f);
            
        }
        
        
    }
}
