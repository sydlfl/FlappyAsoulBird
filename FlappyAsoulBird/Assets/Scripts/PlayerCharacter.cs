using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Animator animator;
    private new Transform transform;

    public float upForce;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    public void Up()
    {
        animator.SetTrigger("Up");
        rigid2d.velocity = Vector2.zero; 
        rigid2d.AddForce(new Vector2(0, upForce));
    }

    public void Die()
    {
        isAlive = false;
        animator.SetTrigger("Die");
        rigid2d.velocity = Vector2.zero;
        GameMode.instance.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void DianaSkill()
    {
        transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, 1f);
    }

    public void QueenSkill()
    {
        transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, 1f);
    }
}
