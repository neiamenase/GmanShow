using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	GameObject player;
	private Rigidbody rb;
	Transform playerTransform;
	UnityEngine.AI.NavMeshAgent nav;
	Animator animator;
<<<<<<< HEAD
	public float montionCompleteTime = 0.5f; // zombie attack animation length = 1.13; Thus, half of it => attack successful
=======
	public float attackCompleteTime = 1f; // zombie attack animation length = 1.13; Thus, half of it => attack successful
	public float stopCompleteTime = 0; 
>>>>>>> 9c2e6c33ddaf0c874d488b625b543618b006d327
	public bool start = false;
	public bool inMotion = false;

	private float stopTimer;
	private float timeBetweenAttack = 3f;
	private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController s;
	private bool beingAttack;

	public float overrideStopTime = 0f;


	PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		animator = GetComponent<Animator>();
		playerHealth = player.GetComponent<PlayerHealth>();
		rb = player.GetComponent<Rigidbody>();
		s = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ();
		s.movementSettings.ForwardSpeed = 12f;
		s.movementSettings.BackwardSpeed = 8f;
		stopTimer = -1f;
		inMotion = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (start) {
			animator.SetBool ("start", true);
		}
		if (!playerHealth.isDead && start) {
			
			if (inMotion) {
				animator.SetBool ("isPlayerNear", false);
				nav.SetDestination (transform.position);
				float stopTime = montionCompleteTime;
				if (overrideStopTime > 0)
					stopTime = overrideStopTime;
				if (stopTimer >= stopTime) {
					inMotion = false;
					overrideStopTime = 0f;
				}
				stopTimer += Time.deltaTime;
			} else {
				stopTimer = 0f;
				float dist = Vector3.Distance (playerTransform.position, transform.position);
<<<<<<< HEAD

				if ((dist <= nav.stoppingDistance + 1f) && beingAttack) { // isnear and being attacked
					nav.SetDestination (transform.position);
					attackEnd ();
					animator.SetInteger ("stopType", Random.Range (0, 3));
					overrideStopTime = 1f;
					inMotion = true;
					beingAttack = false;
=======
				if (dist <= nav.stoppingDistance + 1f) {
					animator.SetBool ("isPlayerNear", true);
					animator.SetInteger ("attackType", Random.Range (1, 3));
					timer += Time.deltaTime;
					if (timer >= attackCompleteTime + timeBetweenAttack) {
						attackEnd ();
						animator.SetInteger ("stopType", Random.Range (1, 2));

						stopCompleteTime = 1.2f;
						stopTimer = 0f;

						timer = 0f;
						timeBetweenAttack = 0.5f;
					}
>>>>>>> 9c2e6c33ddaf0c874d488b625b543618b006d327

				} else if (dist <= nav.stoppingDistance + 1f) {
					nav.SetDestination (transform.position);
					animator.SetBool ("isPlayerNear", true);
					animator.SetInteger ("attackType", Random.Range (0, 4));
					inMotion = true;
					beingAttack = true;
				} else {
					if (beingAttack) {
						beingAttack = false;
						animator.SetInteger ("stopType", 0);
					}
					nav.SetDestination (playerTransform.transform.position);
					animator.SetBool ("isPlayerNear", false);
				}
			}
		}
	}

	void attackEnd(){
		playerHealth.TakeDamge ();
		if (playerHealth.isDead) {
			animator.SetBool ("isPlayerDead", true);
		} else {
			rb.velocity = (player.transform.position + transform.forward * 150f);
		}
	}
}
