using UnityEngine;
using System.Collections;

public class Done_WeaponController : DamageableEntity
{
    public GameObject shot;
    public Transform shotSpawn;
    public float delay;

    void Start()
    {
        InvokeRepeating("Fire", delay, m_FireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }
}
