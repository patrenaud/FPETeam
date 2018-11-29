using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : DamageableEntity
{
    [SerializeField]
    private float m_Tilt;

    [SerializeField]
    private ShipData m_ShipData;

    [SerializeField]
    private Done_Boundary m_Boundary;

    [SerializeField]
    private GameObject m_Shot;

    [SerializeField]
    private Transform m_ShotSpawn;

    private EPlayerID m_ID = (EPlayerID)1;

    private float m_Speed;
    private float m_FireRate;
    private float m_NextFire;

    private void Start()
    {
        m_Speed = m_ShipData.Speed;
        m_FireRate = m_ShipData.RateOfFire;
        m_Shield = m_ShipData.Shield;
    }

    public void Init(EPlayerID a_ID)
    {
        m_ID = a_ID;
    }

    private void Update()
    {
        if (Input.GetButton("Fire" + (int)m_ID) && Time.time > m_NextFire)
        {
            m_NextFire = Time.time + m_FireRate;
            Instantiate(m_Shot, m_ShotSpawn.position, m_ShotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal" + (int)m_ID);
        float moveVertical = Input.GetAxis("Vertical" + (int)m_ID);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * m_Speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, m_Boundary.xMin, m_Boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, m_Boundary.zMin, m_Boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -m_Tilt);
    }
}
