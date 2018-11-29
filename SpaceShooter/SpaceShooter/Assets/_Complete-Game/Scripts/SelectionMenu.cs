using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_Ships;

    public void SelectFirstShip(int aIndex)
    {
        GameManager.Instance.P1Ship = m_Ships[aIndex];
        Debug.Log(GameManager.Instance.P1Ship);
    }

    public void SelectSecondShip(int aIndex)
    {
        GameManager.Instance.P2Ship = m_Ships[aIndex];
        Debug.Log(GameManager.Instance.P1Ship);
        Debug.Log(GameManager.Instance.P2Ship);
    }

    public void Play()
    {
        LevelManager.Instance.ChangeLevel("Done_Main");
    }
}
