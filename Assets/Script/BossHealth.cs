using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

	public float initialHealth = 100f;
	public float currentHealth = 0;
	Animator animator;
	public float dieCompleteTime = 15f;
	private float timer;
	public bool isDead = false;
	//private ParticleSystem WalkerParticleSystem;

	void Start () {
		currentHealth = initialHealth;
		animator = GetComponent<Animator>();
		timer = 0;

//		WalkerParticleSystem = GameObject.Find("Walker").GetComponent<ParticleSystem>();
//		WalkerParticleSystem.Stop();

	}

	void Update(){
		if (isDead) {
			Die ();
		}
	}


	public void TakeDamage(float amount)
	{
		//WalkerParticleSystem.Play();
		Debug.Log("Current HP:" + amount);
		currentHealth -= amount;
		if(currentHealth <= 0f)
		{
			isDead = true;
		}
	}

	public void Die()
	{
		if (timer == 0) {
			animator.SetBool ("attackFront", true);
		}
		if (timer >= dieCompleteTime) {
			Destroy (gameObject);
			timer = 0;
			isDead = false;
		}
		timer += Time.deltaTime;
	}
}
