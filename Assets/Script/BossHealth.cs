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
<<<<<<< HEAD
		if (bossScript.start) {
			Debug.Log ("Current HP:" + amount);
			currentHealth -= amount;
			if (currentHealth < 100 && currentHealth % 10 == 0) {
				animator.SetTrigger ("getHit");
				bossScript.inMotion = true;
			}
			if (currentHealth <= 0f) {
				animator.SetBool ("isDead", true);
				isDead = true;
			} 
=======
		Debug.Log("Current HP:" + amount);
		currentHealth -= amount;
		if(currentHealth <= 0f)
		{
			isDead = true;
>>>>>>> 9c2e6c33ddaf0c874d488b625b543618b006d327
		}
	}

	public void Die()
	{
		if (timer == 0) {
			animator.SetBool ("gethit", true);
		}
		if (timer >= dieCompleteTime) {
			Destroy (gameObject);
			timer = 0;
			isDead = false;
		}
		timer += Time.deltaTime;
	}
}
