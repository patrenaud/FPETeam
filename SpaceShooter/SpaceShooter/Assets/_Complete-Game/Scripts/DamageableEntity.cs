using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_Explosion;

    [SerializeField]
    private ShipData m_ShipData;

    protected int m_Score = 0;
    protected float m_Shield;
    protected float m_Speed;
    protected float m_FireRate;

    private void Start()
    {
        m_Score = m_ShipData.Score;
        m_Speed = m_ShipData.Speed;
        m_FireRate = m_ShipData.RateOfFire;
        m_Shield = m_ShipData.Shield;
    }

    public void ReceiveHit()
    {
        m_Shield--;
        if (m_Shield <= 0)
        {
            Instantiate(m_Explosion, transform.position, transform.rotation);
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(m_Score);

            Destroy(gameObject);
            //GameManager.Instance.AddScore(m_Score);
        }
    }

    public void Kill()
    {
        m_Shield = 1;
        ReceiveHit();
    }
}
