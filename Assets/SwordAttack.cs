using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 3;
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;

    private void Start() {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    // Update is called once per frame
    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null) {
                enemy.Health -= damage;
            }
        }
    }

}
