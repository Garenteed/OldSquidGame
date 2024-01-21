using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public event EventHandler OnTowerDestroy;


    [Header("TowerSetting")]
    [SerializeField] protected int maxHealth = 1000; 
    [SerializeField] private MMFeedbacks damageFeedback;
    [SerializeField] private MMFeedbacks deathFeedback;
    [SerializeField] private Collider2D towerCollider;




    public void GettingAttacked(int damage = 100)
    {
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            OnTowerDestroy?.Invoke(this, EventArgs.Empty);
            deathFeedback.PlayFeedbacks();
            Destroy(gameObject,1f);

        }
        else
        {
            damageFeedback.PlayFeedbacks();
            
        }
 
    }
}
