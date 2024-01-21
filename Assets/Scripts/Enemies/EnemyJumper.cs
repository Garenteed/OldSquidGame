using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    [SerializeField] private bool _goingToTheEndCheck = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.GetGoingToEnd() == _goingToTheEndCheck)
            {
                enemy.StartCoroutine(enemy.PerformJump());
            }

        }
    }

}
