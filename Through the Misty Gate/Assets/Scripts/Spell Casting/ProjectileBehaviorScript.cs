using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviorScript : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;
    private bool _attributed = false;

    
    // Update is called once per frame
    void Update()
    {
        if (!_attributed)
            return;

        transform.position += _speed * Time.deltaTime * _direction;

    }

    public void SetAttributes(Vector3 direction, float speed)
    {
        _direction = direction;
        _speed = speed;
        _attributed = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Enemy"))
        //{
            //other.gameObject.GetComponent<Enemy>().ReceiveAttack();
        //}
        if (other.gameObject.CompareTag("Player"))
        {
            // nothing
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
