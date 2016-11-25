using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExtremeLevelSelector : MonoBehaviour {

    public static ExtremeLevelSelector m_instance;

    public List<GameObject> L_extremeLevels = new List<GameObject>();
    public List<GameObject> L_itemsTurnOff = new List<GameObject>();

    void Awake()
    {
        m_instance = this;
    }

    public void SelectExtreme(int LevelChoice)
    {
        if (L_extremeLevels[LevelChoice] != null)
        {
            L_extremeLevels[LevelChoice].SetActive(true);
            foreach (GameObject Obj in L_itemsTurnOff)
            {
                Obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject Obj in L_extremeLevels)
                Obj.SetActive(false);
        }
    }

}
