using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Setting")]


    [SerializeField] private float _velocity;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _gemPlace;
    [SerializeField] private float _movingCoolDown = 1f;
    [SerializeField] private float _movingDuration = 1f;

    [SerializeField] private Animator _animator;
    [SerializeField] private float _health;

    [SerializeField] private MMFeedbacks _teleportFeedback;
    [SerializeField] private MMFeedbacks _deathFeedback;
    [SerializeField] private MMFeedbacks _takeDamageFeedback;
    [SerializeField] private MMFeedbacks _stunFeedback;

    public event EventHandler EnemyDead;
    private float _moveTime = 0f;
    private Tower _targetTower;

    private Vector2 _direction = Vector2.left;
    private bool _goingToTheEnd = true;
    private bool _jumping = false;
    private bool _teleporting = false;
    private bool _alive = true;
    private bool _attacking = false;
    public bool _stunned = false;
    [SerializeField] private GameObject crwon;


    [Header("JumpSetting")]
    [SerializeField] private Vector2 jumpForceVector;

    enum EnemyStates
    {
        enemy_Jump,
        enemy_Attack,
        enemy_Walk,
        enemy_Idle,
    }

    private void Update()
    {
        if (_jumping) return;
        if (_teleporting) return;
        if (!_alive) return;
        if (_attacking) return;
        if (_stunned) return;

        _moveTime += Time.deltaTime;
        EnemyMovement();


    }
    private void EnemyMovement()
    {
        PlayAnimation(EnemyStates.enemy_Walk);
        if (_moveTime > (_movingCoolDown + _movingDuration))
        {
            _moveTime = 0f;
            _rb.velocity = Vector2.zero;
        }

        if (_moveTime > _movingCoolDown)
        {


            _rb.velocity = new Vector2(_direction.x * _velocity, _rb.velocity.y);
            if (_rb.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            if (_rb.velocity.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

        }

    }

    public IEnumerator PerformJump()
    {
        PlayAnimation(EnemyStates.enemy_Jump);
        _jumping = true;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(jumpForceVector.x * _direction.x, jumpForceVector.y));
        yield return new WaitForSeconds(1f);
        _jumping = false;
    }

    public void TeleportFeedback()
    {
        _teleporting = true;
        _teleportFeedback.PlayFeedbacks();
        StartCoroutine(SetBackTeleport());

    }

    IEnumerator SetBackTeleport()
    {

        yield return new WaitForSeconds(0.3f);
        _teleporting = false;
    }

    public bool GetGoingToEnd()
    {
        return _goingToTheEnd;
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void ChangeGoingToTheEnd()
    {
        if (_goingToTheEnd)
        {
            _direction = -_direction;
            _goingToTheEnd = !_goingToTheEnd;
            crwon.SetActive(true);
        }
    }

    public Transform GetGemPlace()
    {
        return _gemPlace;
    }

    private void PlayAnimation(EnemyStates state)
    {
        _animator.Play(state.ToString());
    }

    public void TakeDamage(float damage)
    {

        _health -= damage;
        if (_health <= 0)
        {
            _alive = false;
            _deathFeedback.PlayFeedbacks();
            _rb.velocity = Vector2.zero;
            Destroy(gameObject, 1f);
        }
        else
        {
            _takeDamageFeedback.PlayFeedbacks();
        }
    }


    private void _wallnutScript_OnTowerDestroy(object sender, System.EventArgs e)
    {
        _attacking = false;
        CancelInvoke("attackTower");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Tower>(out Tower targetTower))
        {
            targetTower.OnTowerDestroy += _wallnutScript_OnTowerDestroy;
            _attacking = true;
            _rb.velocity = Vector2.zero;
            _targetTower = targetTower;
            InvokeRepeating("attackTower", 1f, 1f);

        }

    }
    private void attackTower()
    {
        PlayAnimation(EnemyStates.enemy_Attack);
        _targetTower.GettingAttacked();

    }




    private void OnDestroy()
    {
        EnemyDead?.Invoke(this, EventArgs.Empty);
        CancelInvoke("attackTower");
    }

    public void GetStunned()
    {
        _stunned = true;
        _stunFeedback.PlayFeedbacks();
        CancelInvoke("attackTower");
        StartCoroutine(remove());

    }
    IEnumerator remove()
    {
        yield return new WaitForSeconds(2f);
        _stunned = false;
    }

    public void RemoveStun()
    {
        _stunned = false;
    }

}
