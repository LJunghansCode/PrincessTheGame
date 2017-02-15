using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;
	AudioSource StepSound;




	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		StepSound = GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		
		if (Input.GetKeyDown (KeyCode.W)){
			StepSound.Play ();
		}
		if (Input.GetKeyUp (KeyCode.W) && Input.GetKey (KeyCode.A) == false && Input.GetKey (KeyCode.S) == false && Input.GetKey (KeyCode.D) == false){
			StepSound.Stop();

		}
		if (Input.GetKeyDown (KeyCode.A)){
			StepSound.Play ();
		}
		if (Input.GetKeyUp (KeyCode.A) && Input.GetKey (KeyCode.D) == false && Input.GetKey (KeyCode.W) == false && Input.GetKey (KeyCode.S) == false) {
			StepSound.Stop();

		}
		if (Input.GetKeyDown (KeyCode.S)){
			StepSound.Play ();
		}
		if (Input.GetKeyUp (KeyCode.S) && Input.GetKey (KeyCode.A) == false && Input.GetKey (KeyCode.D) == false && Input.GetKey (KeyCode.W) == false) {
			StepSound.Stop();

		}
		if (Input.GetKeyDown (KeyCode.D)){
			StepSound.Play ();
		}
		if (Input.GetKeyUp (KeyCode.D) && Input.GetKey (KeyCode.W) == false && Input.GetKey (KeyCode.S) == false && Input.GetKey (KeyCode.A) == false ){
			StepSound.Stop();

		}







		if (movement_vector != Vector2.zero) {
			anim.SetBool ("is_walking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);


		} else {
			anim.SetBool ("is_walking", false);
		}
		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);

	}
}
