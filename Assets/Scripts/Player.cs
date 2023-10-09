using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Rigidbody2D _blockRb;

    private Rigidbody2D _rb;

    private float _dirX;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*if(Input.GetMouseButton(0))
        {
            Vector3 touchPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPose.x < 0)
            {
                _rb.AddForce(Vector2.left * _moveSpeed);
            } else
            {
                _rb.AddForce(Vector2.right * _moveSpeed);
            }

        } else
        {
            _rb.velocity = Vector2.zero;
        }*/
        _dirX = Input.acceleration.x * _moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_dirX, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            _blockRb.gravityScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddSpeed()
    {
        _moveSpeed += 0.05f;
    }
}
