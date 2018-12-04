using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ButtonGroup
{
    [SerializeField]
    private List<Button> m_Buttons;

    public List<Button> Buttons
    {
        get { return m_Buttons; }
        set { m_Buttons = value; }
    }
}

public class SelectionMenu : MonoBehaviour
{
    [SerializeField]
    private List<ButtonGroup> m_Buttons; 

    [SerializeField]
    private List<GameObject> m_Ships;

    [SerializeField]
    private GameObject m_Panel1Player;

    [SerializeField]
    private GameObject m_Panel2Player;

    private void Start()
    {
        for (int i = 0; i < m_Buttons.Count; i++)
        {
            for (int j = 0; j < m_Buttons[i].Buttons.Count; j++)
            {
                if (GameManager.Instance.ShipAvailable[j])
                {
                    m_Buttons[i].Buttons[j].interactable = true;
                }
                else
                {
                    m_Buttons[i].Buttons[j].interactable = false;
                }
            }
        }

        if(GameManager.Instance.IsSingle)
        {
            GameManager.Instance.P1Ship = m_Ships[0];
            m_Panel1Player.SetActive(true);
            m_Panel2Player.SetActive(false);
        }
        else
        {
            GameManager.Instance.P1Ship = m_Ships[0];
            GameManager.Instance.P2Ship = m_Ships[0];
            m_Panel2Player.SetActive(true);
            m_Panel1Player.SetActive(false);
        }
    }

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
