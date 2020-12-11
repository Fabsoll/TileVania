using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 1f;

    Rigidbody2D enemyRigidbody;
    BoxCollider2D flipCondition;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        flipCondition = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (IsFlippedRight())
        {
            enemyRigidbody.velocity = new Vector2(enemySpeed, 0f);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(-enemySpeed, 0f);
        }
        
    }
    private bool IsFlippedRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(enemyRigidbody.velocity.x * -1, 1f);
    }
}
