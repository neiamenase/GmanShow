using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
	int shootableMask;

	public Camera fpsCam;
	public float fireRadius = 50f;

    private ParticleSystem gunParticleSystem;

    public Rect windowRect = new Rect(0, 0, 300, 120);


    // Use this for initialization
    void Start () {
		shootableMask = LayerMask.GetMask ("Shootable");
        gunParticleSystem = GameObject.Find("M4A1 Sopmod").GetComponent<ParticleSystem>();
        gunParticleSystem.Stop();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
            Shoot();
        }
	}

    void Shoot()
    {
        Debug.Log("EnterShoot");
        RaycastHit hit;
        gunParticleSystem.Play();

        if (Physics.Raycast(fpsCam.transform.position , fpsCam.transform.forward, out hit,fireRadius , shootableMask))
        {
            Debug.Log("Shoot:" + hit.transform.name);

            WalkerHealthScript target = hit.transform.GetComponent<WalkerHealthScript>();
            if(target != null)
            {
                Debug.Log("Damage:" + damage);
                target.TakeDamage(damage);
            }
        }
    }
}
