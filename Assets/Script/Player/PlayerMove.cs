using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    [SerializeField,Header("���s���x")] int _walkSpeed = 10;

    private Vector2 _dir = default;
    
    private Rigidbody2D _rb;

    private float _x, _y;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");
        
        _dir = new Vector2(_x,_y);

        _rb.linearVelocity = _dir * _walkSpeed;
    }
}
