using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blocksparkpool : MonoBehaviour {

    public static blocksparkpool m_instance1;

    public GameObject m_poolObject;
    public int m_initialPoolSize;

    public List<GameObject> m_pool;
    void Awake()
    {
        m_instance1 = this;
        DontDestroyOnLoad(m_instance1.gameObject);
    }

	// Use this for initialization
    void Start()
    {
        m_pool = new List<GameObject>();
        {
            for (int i = 0; i < m_initialPoolSize; i++)
            {
                GameObject tempObj = Instantiate(m_poolObject) as GameObject;
                tempObj.SetActive(false);
                m_pool.Add(tempObj);
            }
        }
    }

    public GameObject NewObject()
    {
        for (int i = 0; i < m_pool.Count; i++)
        {
            if (m_pool[i].activeInHierarchy == false)
            {
                return m_pool[i];
            }
        }
        return null;
    }
}
