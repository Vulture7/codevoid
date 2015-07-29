using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	Animator an;
	public Camera MainCamera;
	public GameObject LookReference;
	public GameObject TurnReference;
	public GameObject PlayerModel;
	CharacterController cc;

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

		cc = GetComponent <CharacterController> ();

		Gunshot = GetComponent <AudioSource>();

		normalFOV = MainCamera.fieldOfView;
	}

	Vector3 movement = Vector3.zero;

	// Update is called once per frame
	void Update () {
		UpdateRotation = false;

		if (!cc.isGrounded)
			movement.y -= Time.deltaTime;
		else
			movement.y = 0f;

		//Begin horrible, awful code that will be optimized soon

		if (an.GetBool("Shooting"))
		    PlayerModel.transform.rotation = Quaternion.LookRotation(transform.forward);

		if (Input.GetMouseButtonDown (1)) {
			ADS = true;
			an.SetBool("Shooting", true);
			ShootingTimer = 0.5f;
		}
		if (Input.GetMouseButtonUp (1)) {
			ADS = false;
		}

		//Forward
		if (Input.GetKey (KeyCode.W)) {
			if (an.GetBool("Shooting")) {
				transform.position += transform.forward * Time.deltaTime * AimMoveSpeed;
			}
			else
				transform.position += transform.forward * Time.deltaTime * MoveSpeed;
			
			PlayerModel.transform.rotation = Quaternion.LookRotation(transform.forward);
			
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
			} else {
				an.SetBool ("RunForward", true);
				transform.position -= transform.right * Time.deltaTime * MoveSpeed;
				PlayerModel.transform.rotation = Quaternion.LookRotation(-transform.right);
			}
			
			UpdateRotation = true;
		}
		if (!Input.GetKey (KeyCode.D) && an.GetBool ("RunForward")) {
			an.SetBool ("StrafeRight", false);
		}

		//Right strafe
		if (Input.GetKey (KeyCode.D)) {
			if (an.GetBool("Shooting")){
				an.SetBool ("StrafeRight", true);
				transform.position += transform.right * Time.deltaTime * AimMoveSpeed;
			} else {
				PlayerModel.transform.rotation = Quaternion.LookRotation(transform.right);
				transform.position += transform.right * Time.deltaTime * MoveSpeed;
				an.SetBool ("RunForward", true);
			}
			
			UpdateRotation = true;
		}
		if (!Input.GetKey (KeyCode.D) && an.GetBool ("RunForward")) {
			an.SetBool ("StrafeRight", false);
		}
		
		//backwards
		if (Input.GetKey (KeyCode.S)) {
			if (an.GetBool("Shooting")){
				an.SetBool ("WalkBackward", true);
				transform.position -= transform.forward * Time.deltaTime * AimMoveSpeed;
			} else {
				PlayerModel.transform.rotation = Quaternion.LookRotation(-transform.forward);
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
			UpdateRotation = true;
			GunFlare.Play();
			Gunshot.Play();
			an.SetTrigger("Shoot");
			an.SetBool ("Shooting", true);
			ShootingTimer = 0.5f;
			PlayerModel.transform.rotation = Quaternion.LookRotation(transform.forward);
		}
		if (ShootingTimer > 0 && !ADS) {
			ShootingTimer -= Time.deltaTime;
		}
		if (an.GetBool ("Shooting") && ShootingTimer < 0)
			an.SetBool ("Shooting", false);

		if (ADS) {
			UpdateRotation = true;
			MainCamera.fieldOfView = Mathf.Lerp (MainCamera.fieldOfView, normalFOV * 0.7f, (0.99f * Time.deltaTime*5));
		} else {
			MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, normalFOV, 0.99f*(Time.deltaTime*10));
		}

		if (UpdateRotation) {
			transform.rotation = TurnReference.transform.rotation;
			TurnReference.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		}

		cc.Move(movement);
	}
}

