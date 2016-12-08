using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExtremeLevelSelector : MonoBehaviour {

    public static ExtremeLevelSelector m_instance;

    public List<GameObject> L_extremeLevels = new List<GameObject>();

    void Awake()
    {
        m_instance = this;
    }

    public void SelectExtreme(int LevelChoice)
    {
        if (L_extremeLevels[LevelChoice] != null)
        {
            L_extremeLevels[LevelChoice].SetActive(true);
        }
    }

    public void TurnOffExtremeProps()
    {
        foreach (GameObject Obj in L_extremeLevels)
        {
            Obj.SetActive(false);
        }
    }

}
