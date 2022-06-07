using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : OffensiveSpell {
    public FireballSpell() : base("Fireball", 5, 1, false, 30, 12.5, 4.25) {}

    public override void Cast(Vector3 position, Vector3 target) {
        rb = transform.GetComponent<Rigidbody2D>();

        direction = target - position;
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = position;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        direction /= direction.magnitude;

        if (chargeTime > 0)
            StartCoroutine(ChargeAttack());
        else
            rb.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Enemy>().ReceiveAttack(this);
        }
        if (other.gameObject.CompareTag("Player")) {
           // nothing
        }
        else {
            Destroy(gameObject);
        }
    }

}
