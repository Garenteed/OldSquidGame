using MoreMountains.Feedbacks;
using System;
using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _floorLayer;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Collider2D _playerCollider;

    [Header("HandSetting")]

    [SerializeField] private Transform _playerHand;
    private TowerSO _tower;
    private GameObject _gameObjectToHold;
    private TowerPlacer placer = null;


    private bool colliderState = true;

    private bool _grounded = false;



    private PlayerInputs _playerInputs;
    

    private void Start()
    {
        _playerInputs = PlayerInputs.Instance;
        _playerInputs.jumpPerformed += _playerInputs_jumpPerformed;
        _playerInputs.placeBuildingPerformed += _playerInputs_placeBuildingPerformed;
        _playerInputs.moveDownPerformed += _playerInputs_moveDownPerformed;
    }


    private void Update()
    {   
    }

    private void FixedUpdate()
    {
        CheckGround();
        CharacterMovement();
    }
    private void CheckGround()
    {
        float capsuleWidth = 1.8f;
        float capsuleHeight = 0.3f;
        _grounded = Physics2D.OverlapCapsule(_groundCheck.position, new Vector2(capsuleWidth, capsuleHeight), CapsuleDirection2D.Horizontal, 0, _groundLayers);

    }

    private void CharacterMovement()
    {
        Vector2 playerMovementDirection = _playerInputs.GetMovementVectorNormalized();
        //Horizontal control
        Vector3 vector3Movement = new Vector3(playerMovementDirection.x * _speed * Time.deltaTime, _rb.velocity.y, 0);
        _rb.velocity = vector3Movement;

        //Character Rotation
        if (playerMovementDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (playerMovementDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void _playerInputs_placeBuildingPerformed(object sender, System.EventArgs e)
    {
        if(placer != null)
        {
            Destroy(_gameObjectToHold);
            _tower = null;

        }
    }

    private void _playerInputs_jumpPerformed(object sender, System.EventArgs e)
    {
       
        if (_grounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void _playerInputs_moveDownPerformed(object sender, EventArgs e)
    {
        if (colliderState)
        {
            colliderState = false;
            StartCoroutine(DisableCollider());
        }

    }

    private IEnumerator DisableCollider()
    {
        _playerCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        _playerCollider.enabled = true;
        colliderState = true;
    }

    public void TakeGameObject(TowerSO tower)
    {
        if(_tower == tower)
        {
            Destroy(_gameObjectToHold);
            _tower = null;
            return;
        }
        _tower = tower;
        if (_gameObjectToHold != null)
        {
            Destroy(_gameObjectToHold);
        }
        _gameObjectToHold = Instantiate(tower.smallTower);
        _gameObjectToHold.transform.parent = _playerHand;
        _gameObjectToHold.transform.localPosition = Vector3.zero;
         
    }
    public TowerSO GetTowerSO()
    {
        return _tower;
    }

    public void SetPlacer(TowerPlacer place)
    {
        placer = place;
    }

    public void DeletePlacer()
    {
        placer = null;
    }


}
