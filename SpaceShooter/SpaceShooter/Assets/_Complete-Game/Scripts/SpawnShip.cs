using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShip : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_Transforms;

	private void Start ()
    {
		if(GameManager.Instance.IsSingle)
        {
            Instantiate(GameManager.Instance.P1Ship, Vector3.zero, Quaternion.identity).GetComponent<Done_PlayerController>().Init(EPlayerID.PlayerOne);
        }
        else
        {
            Instantiate(GameManager.Instance.P1Ship, m_Transforms[0].position, Quaternion.identity).GetComponent<Done_PlayerController>().Init(EPlayerID.PlayerOne);
            Instantiate(GameManager.Instance.P2Ship, m_Transforms[1].position, Quaternion.identity).GetComponent<Done_PlayerController>().Init(EPlayerID.PlayerTwo);
        }
    }
}
