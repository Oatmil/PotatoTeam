using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class hitsparkpool : MonoBehaviour {

    public static hitsparkpool m_instance;

    public GameObject m_poolObject;
    public int m_initialPoolSize;

    public List<GameObject> m_pool;
    void Awake()
    {
        m_instance = this;
        DontDestroyOnLoad(m_instance.gameObject);
    }
	// Use this for initialization
    void Start()
    {
        m_pool = new List<GameObject>(); 
        {
            for (int i = 0; i < m_initialPoolSize; i++)
            {
                GameObject newObj = Instantiate(m_poolObject) as GameObject;
                newObj.SetActive(false);
                m_pool.Add(newObj);
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
