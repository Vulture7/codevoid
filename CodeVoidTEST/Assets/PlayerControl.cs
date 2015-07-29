using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public RuntimeAnimatorController rac;
	Animator an;
	public GameObject LookReference;
	public GameObject TurnReference;
	CharacterController cc;

	AudioSource Gunshot;
	public ParticleSystem GunFlare;

	bool UpdateRotation = false;
	bool AlreadyUpdating = false;
	float ShootingTimer = 0f;

	public float MoveSpeed;
	public float AimMoveSpeed;
	Quaternion LastTurn;

	// Use this for initialization
	void Start () {
		an = GetComponent <Animator> ();

		cc = GetComponent <CharacterController> ();

		Gunshot = GetComponent <AudioSource>();
	}

	Vector3 movement = Vector3.zero;

	// Update is called once per frame
	void Update () {
		UpdateRotation = false;

		if (!cc.isGrounded)
			movement.y -= Time.deltaTime;
		else
			movement.y = 0f;

		if (Input.GetKey (KeyCode.W)) {
			if (an.GetBool("Shooting"))
				transform.position += transform.forward * Time.deltaTime * AimMoveSpeed;
			else
				transform.position += transform.forward * Time.deltaTime * MoveSpeed;

			UpdateRotation = true;
			an.SetBool ("RunForward", true);
		}
		if (!Input.GetKey (KeyCode.W) && an.GetBool ("RunForward")) {
			an.SetBool ("RunForward", false);
		}

		if (Input.GetMouseButtonDown (0)) {
			UpdateRotation = true;
			GunFlare.Play();
			Gunshot.Play();
			an.SetTrigger("Shoot");
			an.SetBool ("Shooting", true);
			ShootingTimer = 0.5f;
		}
		if (ShootingTimer > 0) {
			ShootingTimer -= Time.deltaTime;
		}
		if (an.GetBool ("Shooting") && ShootingTimer < 0)
			an.SetBool ("Shooting", false);

		if (UpdateRotation) {
			transform.rotation = TurnReference.transform.rotation;
			TurnReference.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		} else
			AlreadyUpdating = false;

		cc.Move(movement);
	}
}

