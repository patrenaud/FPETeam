using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShipData", order = 1)]
public class ShipData : ScriptableObject
{
    [SerializeField] private float m_RateOfFire = 1f;
    [SerializeField] private float m_Speed = 1f;
    [SerializeField] private float m_Shield = 1f;
    [SerializeField] private int m_Score = 0;

    public float RateOfFire
    {
        get { return m_RateOfFire; }
    }

    public float Speed
    {
        get { return m_Speed; }
    }

    public float Shield
    {
        get { return m_Shield; }
    }

    public int Score
    {
        get { return m_Score; }
    }
}