using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponController : DamageableEntity 
{
	[SerializeField]
	private Transform leftshotSpawn;
	[SerializeField]
	private Transform rightshotSpawn;

	private bool m_MoveRight = true;

	private Vector3 m_MoveDir = new Vector3(0.05f, 0f, 0f);

	public GameObject shot;
	public Transform shotSpawn;	

	public float delay;

	private void Start ()
	{
		InvokeRepeating ("Fire", delay, m_FireRate);
		InvokeRepeating ("FireRight", delay, m_FireRate);
		InvokeRepeating ("FireLeft", delay, m_FireRate);

	}

	private void Update()
	{
		if(m_MoveRight)
		{			
			if(transform.position.x >= 6)
			{
				m_MoveRight = false;
				m_MoveDir *= -1;
			}
		}
		else
		{
			if(transform.position.x <= -6)
			{
				m_MoveRight = true;
				m_MoveDir *= -1;
			}
		}
	}

	private void FixedUpdate()
	{
		transform.position += m_MoveDir;
	}

	private void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}

	private void FireRight()
	{
		Instantiate(shot, shotSpawn.position, rightshotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}

	private void FireLeft()
	{
		Instantiate(shot, shotSpawn.position, leftshotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}

}
