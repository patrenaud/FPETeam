using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponController : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_Boss;
	[SerializeField]
	private Transform leftshotSpawn;
	[SerializeField]
	private Transform rightshotSpawn;

	private bool m_MoveRight = true;

	private Vector3 m_MoveDir = new Vector3(0.05f, 0f, 0f);

	public GameObject shot;
	public Transform shotSpawn;	
	
	public float fireRate;
	public float delay;


	private void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
		InvokeRepeating ("FireRight", delay, fireRate);
		InvokeRepeating ("FireLeft", delay, fireRate);
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
