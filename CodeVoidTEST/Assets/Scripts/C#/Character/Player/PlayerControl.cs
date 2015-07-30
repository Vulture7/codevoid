using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	Animator an;
	public Camera MainCamera;
	public GameObject LookReference;
	public GameObject TurnReference;
	public GameObject PlayerModel;
	CharacterController cc;

	public GameObject gun;
	RaycastTest rct;

	AudioSource Gunshot;
	public ParticleSystem GunFlare;

	bool ADS = false;
	bool UpdateRotation = false;
	float ShootingTimer = 0f;

	public float MoveSpeed;
	public float AimMoveSpeed;
	Quaternion LastTurn;

	float normalFOV = 90f;

	// Use this for initialization
	void Start () {
		an = PlayerModel.GetComponent <Animator> ();

		rct = gun.GetComponent <RaycastTest> ();

		cc = GetComponent <CharacterController> ();

		Gunshot = GetComponent <AudioSource>();

		normalFOV = MainCamera.fieldOfView;
	}


	Vector3 movement = Vector3.zero;

	bool 	TURN_RIGHT = false,
			TURN_FWD = true,
			TURN_LEFT = false,
			TURN_BACK = false;

	// Update is called once per frame
	void Update () {
		TURN_RIGHT = false;
		TURN_FWD   = false;
		TURN_LEFT  = false;
		TURN_BACK  = false;

		UpdateRotation = false;

		if (!cc.isGrounded)
			movement.y -= Time.deltaTime;
		else
			movement.y = 0f;

		//Begin horrible, awful code that will be optimized soon

		if (Input.GetMouseButtonDown (1)) {
			ADS = true;
			an.SetBool("Shooting", true);
			ShootingTimer = 0.01f;
		}
		if (Input.GetMouseButtonUp (1)) {
			ADS = false;
			ShootingTimer = 0.02f;
		}

		//Forward
		if (Input.GetKey (KeyCode.W)) {
			if (an.GetBool("Shooting")) {
				transform.position += transform.forward * Time.deltaTime * AimMoveSpeed;
			}
			else
				transform.position += transform.forward * Time.deltaTime * MoveSpeed;

			TURN_FWD = true;

			UpdateRotation = true;
			an.SetBool ("RunForward", true);
		}
		if (!Input.GetKey (KeyCode.W) && an.GetBool ("RunForward")) {
			an.SetBool ("RunForward", false);
		}

		//Left straft
		if (Input.GetKey (KeyCode.A)) {
			if (an.GetBool("Shooting")){
				an.SetBool ("StrafeLeft", true);
				transform.position -= transform.right * Time.deltaTime * AimMoveSpeed;
				TURN_LEFT = false;
			} else {
				TURN_LEFT = true;
				an.SetBool ("RunForward", true);
				transform.position -= transform.right * Time.deltaTime * MoveSpeed;
			}
			
			UpdateRotation = true;
		} //Right strafe
		else if (Input.GetKey (KeyCode.D)) {
			if (an.GetBool("Shooting")){
				TURN_RIGHT = false;
				an.SetBool ("StrafeRight", true);
				transform.position += transform.right * Time.deltaTime * AimMoveSpeed;
			} else {
				TURN_RIGHT = true;
				an.SetBool ("RunForward", true);
				transform.position += transform.right * Time.deltaTime * MoveSpeed;
			}
			
			UpdateRotation = true;
		}
		/*
		if (!Input.GetKey (KeyCode.D) && an.GetBool ("RunForward")) {
			an.SetBool ("StrafeRight", false);
		}*/
		
		//backwards
		if (Input.GetKey (KeyCode.S)) {
			if (an.GetBool("Shooting")){
				an.SetBool ("WalkBackward", true);
				transform.position -= transform.forward * Time.deltaTime * AimMoveSpeed;
				TURN_BACK = false;
			} else {
				TURN_BACK = true;
				an.SetBool ("RunForward", true);
				transform.position -= transform.forward * Time.deltaTime * MoveSpeed;
			}

			UpdateRotation = true;
		}
			
		if (!Input.GetKey (KeyCode.W) && an.GetBool ("RunForward")) {
			an.SetBool ("RunBackward", false);
			an.SetBool ("WalkBackward", false);
		}
		//End horrible, awful code

		if (Input.GetMouseButtonDown (0)) {
			rct.Shoot(gun.transform.forward);
			UpdateRotation = true;
			GunFlare.Play();
			Gunshot.Play();
			an.SetTrigger("Shoot");
			an.SetBool ("Shooting", true);
			ShootingTimer = 0.5f;
		}
		if (ShootingTimer > 0 && !ADS) {
			TURN_FWD = true;
			TURN_RIGHT = false;
			TURN_LEFT = false;
			TURN_BACK = false;
			ShootingTimer -= Time.deltaTime;
		}
		if (an.GetBool ("Shooting") && ShootingTimer < 0)
			an.SetBool ("Shooting", false);

		if (ADS) {
			TURN_FWD = true;
			TURN_RIGHT = false;
			TURN_LEFT = false;
			TURN_BACK = false;
			UpdateRotation = true;
			MainCamera.fieldOfView = Mathf.Lerp (MainCamera.fieldOfView, normalFOV * 0.7f, (0.99f * Time.deltaTime*5));
		} else {
			MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, normalFOV, 0.99f*(Time.deltaTime*10));
		}

		if (TURN_FWD) {
			if (TURN_RIGHT) {
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (Vector3.Lerp (transform.right, transform.forward, 0.5f)), 0.9f * (Time.deltaTime * 10));
			} else if (TURN_LEFT) {
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (Vector3.Lerp (-transform.right, transform.forward, 0.5f)), 0.9f * (Time.deltaTime * 10));
			} else
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (transform.forward), 0.9f * (Time.deltaTime * 10));
		} else if (TURN_BACK) {
			if (TURN_RIGHT) {
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (Vector3.Lerp (transform.right, -transform.forward, 0.5f)), 0.9f * (Time.deltaTime * 20));
			} else if (TURN_LEFT) {
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (Vector3.Lerp (-transform.right, -transform.forward, 0.5f)), 0.9f * (Time.deltaTime * 20));
			} else 
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (-transform.forward), 0.9f * (Time.deltaTime * 10));
		} else if (TURN_RIGHT) {
			PlayerModel.transform.rotation = Quaternion.Lerp(PlayerModel.transform.rotation, Quaternion.LookRotation(transform.right), 0.9f*(Time.deltaTime*10));
		} else if (TURN_LEFT) {
			PlayerModel.transform.rotation = Quaternion.Lerp(PlayerModel.transform.rotation, Quaternion.LookRotation(-transform.right), 0.9f*(Time.deltaTime*10));
		}

		if (UpdateRotation) {
			transform.rotation = TurnReference.transform.rotation;
			TurnReference.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		}

		cc.Move(movement);
	}
}

