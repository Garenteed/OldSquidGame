using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEM : MonoBehaviour
{
    private bool _taken = false;
    private Transform _target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_taken ) return;
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _target = enemy.GetGemPlace();
            _taken = true;
            enemy.ChangeGoingToTheEnd();
            enemy.EnemyDead += Enemy_EnemyDead;

        }
    }

    private void Enemy_EnemyDead(object sender, System.EventArgs e)
    {
        _taken = false;
        _target = null;
    }

    private void Update()
    {
        if (!_taken) return;

        if(_target == null)
        {
            _taken = false;
        }

        transform.position = _target.position;

        
    }
}
