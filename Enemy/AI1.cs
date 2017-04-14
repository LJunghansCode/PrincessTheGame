using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI1 : MonoBehaviour {


	private Vector3 Player;
	private Vector2 PlayerDirection;
	private float Xdif;
	private float Ydif;
	private float speed;
	public Rigidbody2D rb;
	private int wall;
	private float distance;
	Animator anim;
	EnemyAttack enemyAttack;


	void Start () {
		speed = .2f;
		rb = GetComponent<Rigidbody2D> ();
        enemyAttack = GetComponent <EnemyAttack>();
		anim = GetComponent<Animator> ();
		wall = LayerMask.GetMask ("Wall");
	}
	// Update is called once per frame
	void Update (){
		anim.SetBool ("is_walking", false);
		distance = Vector2.Distance (Player, transform.position);
        Player = GameObject.Find ("Player").transform.position;//Assign to player transform
		if (distance < 4f) {
            Chase();
		}
			
	}
    void Chase() {
        Xdif = Player.x - transform.position.x; //diff of xvalue
        Ydif = Player.y - transform.position.y; //diff of yvalue
        PlayerDirection = new Vector2(Xdif, Ydif);
        if (!Physics2D.Raycast(transform.position, PlayerDirection, .2f, wall) && distance > .3f)
        {
            rb.AddForce(PlayerDirection.normalized * speed);
            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", PlayerDirection.x);
            anim.SetFloat("input_y", PlayerDirection.y);
        }
        else
        {
            anim.SetBool("is_walking", false);
            enemyAttack.Attack();
        }


    }


}
