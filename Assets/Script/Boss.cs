using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	GameObject player;
	private Rigidbody rb;
	Transform playerTransform;
	UnityEngine.AI.NavMeshAgent nav;
	Animator animator;
	public float attackCompleteTime = 1f; // zombie attack animation length = 1.13; Thus, half of it => attack successful
	public float stopCompleteTime = 0; 
	public bool start = false;
	private float timer;
	private float stopTimer;
	private float timeBetweenAttack = 3f;
	private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController s;

	PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		animator = GetComponent<Animator>();
		playerHealth = player.GetComponent<PlayerHealth>();
		rb = player.GetComponent<Rigidbody>();
		timer = 0f;
		s = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ();
		s.movementSettings.ForwardSpeed = 12f;
		s.movementSettings.BackwardSpeed = 8f;
		stopCompleteTime = 0f;
		stopTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (start) {
			animator.SetBool ("start", true);
		}
		if (!playerHealth.isDead && start) {
			
			if (stopTimer >= stopCompleteTime) {
				float dist = Vector3.Distance (playerTransform.position, transform.position);
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

				} else {
					nav.SetDestination (playerTransform.transform.position);
					animator.SetBool ("isPlayerNear", false);
					timer = 0f;
					timeBetweenAttack = 0f;
					stopTimer = 0f;
					stopCompleteTime = 0f;
				}

			} else {
				stopTimer += Time.deltaTime;
			}


		}
	}

	void attackEnd(){
		playerHealth.TakeDamge ();
		if (playerHealth.isDead) {
			animator.SetBool ("isPlayerDead", true);
		} else {
			rb.velocity = (player.transform.position + transform.forward * 150f);
			//rb.AddForce (player.transform.position + transform.forward * 200f, ForceMode.Impulse);
		}
	}
}
