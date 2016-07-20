using UnityEngine;
using System.Collections;

public class HazardScript : MonoBehaviour {
    public GameObject m_Environment1Haz;
    public GameObject m_Environment2Haz;
    public GameObject m_Environment3Haz;
    public GameObject m_Environment4Haz;
    public GameObject m_Environment5Haz;

    public void SetHazard(int m_randomNumber)
    {
        if (m_randomNumber == 0)
        {
            m_Environment1Haz.SetActive(true);
            m_Environment2Haz.SetActive(false);
            m_Environment3Haz.SetActive(false);
            m_Environment4Haz.SetActive(false);
            m_Environment5Haz.SetActive(false);
        }
        if (m_randomNumber == 1)
        {
            m_Environment1Haz.SetActive(false);
            m_Environment2Haz.SetActive(true);
            m_Environment3Haz.SetActive(false);
            m_Environment4Haz.SetActive(false);
            m_Environment5Haz.SetActive(false);
        }
        if (m_randomNumber == 2)
        {
            m_Environment1Haz.SetActive(false);
            m_Environment2Haz.SetActive(false);
            m_Environment3Haz.SetActive(true);
            m_Environment4Haz.SetActive(false);
            m_Environment5Haz.SetActive(false);
        }
        if (m_randomNumber == 3)
        {
            m_Environment1Haz.SetActive(false);
            m_Environment2Haz.SetActive(false);
            m_Environment3Haz.SetActive(false);
            m_Environment4Haz.SetActive(true);
            m_Environment5Haz.SetActive(false);
        }
        if (m_randomNumber == 4)
        {
            m_Environment1Haz.SetActive(false);
            m_Environment2Haz.SetActive(false);
            m_Environment3Haz.SetActive(false);
            m_Environment4Haz.SetActive(false);
            m_Environment5Haz.SetActive(true);
        }
        if (m_randomNumber == 5)
        {
            m_Environment1Haz.SetActive(false);
            m_Environment2Haz.SetActive(false);
            m_Environment3Haz.SetActive(false);
            m_Environment4Haz.SetActive(false);
            m_Environment5Haz.SetActive(false);
        }
    }
}
