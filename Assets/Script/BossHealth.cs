using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

	public float initialHealth = 100f;
	public float currentHealth = 0;
	Animator animator;
	public float dieCompleteTime = 10f;
	private float timer;
	public bool isDead = false;
	Boss bossScript;
	//private ParticleSystem WalkerParticleSystem;

	void Start () {
		currentHealth = initialHealth;
		animator = GetComponent<Animator>();
		timer = 0;
		bossScript = GetComponent<Boss> ();

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
		if (bossScript.start) {
			Debug.Log ("Current HP:" + amount);
			currentHealth -= amount;
			if (currentHealth < 100 && currentHealth % 10 == 0) {
				animator.SetTrigger ("getHit");
				bossScript.stopCompleteTime = 1f;
			}
			if (currentHealth <= 0f) {
				animator.SetBool ("isDead", true);
				isDead = true;
			} 
		}
	}

	public void Die()
	{
		if (timer >= dieCompleteTime) {
			Destroy (gameObject);
			timer = 0;
			isDead = false;
		}
		timer += Time.deltaTime;
	}
}
