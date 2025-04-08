using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    [SerializeField,Header("歩行速度")] float _walkSpeed = 10;

    private Vector2 _dir = default;
    
    private Rigidbody2D _rb;

    private float _x, _y;

    private float _timer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");

        _timer += Time.deltaTime;
        
        if(_timer > _walkSpeed)
        {
            this.transform.position = new Vector2(this.transform.position.x + _x, this.transform.position.y + _y);
            if(_x == 0 || _y == 0)
                _timer = 0;
        }
    }
}
