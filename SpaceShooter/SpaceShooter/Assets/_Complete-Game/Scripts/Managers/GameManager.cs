using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool m_IsSingle = true;
    private bool[] m_ShipAvailable = { true, true, false };

    private int m_Score = 0;

    private GameObject m_P1Ship = null;
    private GameObject m_P2Ship = null;

    public int Score
    {
        get { return m_Score; }
        set { m_Score = value; }
    }

    public bool IsSingle
    {
        get { return m_IsSingle; }
        set { m_IsSingle = value; }
    }
    public bool[] ShipAvailable
    {
        get { return m_ShipAvailable; }
        set { ShipAvailable = value; }
    }

    public GameObject P1Ship
    {
        get { return m_P1Ship; }
        set { m_P1Ship = value; }
    }
    public GameObject P2Ship
    {
        get { return m_P2Ship; }
        set { m_P2Ship = value; }
    }

    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        if(m_Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            m_Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int newScoreValue)
    {
        m_Score += newScoreValue;
    }
}
