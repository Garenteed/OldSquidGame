using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [Header("PortalSetting")]
    [SerializeField] private bool _goingToTheEndCheck;
    [SerializeField] private Teleporter _otherPortal;
    [SerializeField] private Vector2 direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {

            StartCoroutine(TeleportTarget(enemy));
            
        }
    }

    private IEnumerator TeleportTarget(Enemy enemy)
    {
        if (enemy.GetGoingToEnd() == _goingToTheEndCheck)
        {
            enemy.TeleportFeedback();
            yield return new WaitForSeconds(0.3f);
            enemy.gameObject.transform.position = _otherPortal.transform.position;
            enemy.SetDirection(direction);
            
        }
        
    }
}
