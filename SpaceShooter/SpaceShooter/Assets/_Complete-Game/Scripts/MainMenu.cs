using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void SetSingleOrDual(bool aIsSingle)
    {
        GameManager.Instance.IsSingle = aIsSingle;
        LevelManager.Instance.ChangeLevel("SelectionMenu");
    }
}
