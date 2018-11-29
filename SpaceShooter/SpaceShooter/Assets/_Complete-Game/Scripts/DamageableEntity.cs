using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_Explosion;

    protected float m_Shield = 1;

    public void ReceiveHit()
    {
        m_Shield--;
        if (m_Shield <= 0)
        {
            Instantiate(m_Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            //call to gamecontroller to remove himself;
        }
    }
}
