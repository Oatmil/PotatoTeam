﻿using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {
    public float m_RespawnDelay;
	public GameObject m_spawnPoint3;
	public GameObject m_spawnPoint2;
	public GameObject m_spawnPoint1;
	//public GameObject m_DeathBoom;

	GameObject[] m_SpawnPointsArray = new GameObject[3];
    GameObject[] m_players;

    public AudioClip m_DeathAudio;
    AudioSource m_audio;

    void Awake()
    {
		m_audio = GetComponent<AudioSource>();
    }

	void Start()
	{
		m_SpawnPointsArray [0] = m_spawnPoint1;
		m_SpawnPointsArray [1] = m_spawnPoint2;
		m_SpawnPointsArray [2] = m_spawnPoint3;
        m_players = GameObject.FindGameObjectsWithTag("Player");
	}

	void OnTriggerEnter2D (Collider2D col)
	{
        if (col.transform.tag == "Player")
        {
            PlayDeathSound();
            col.transform.GetComponent<player1Controler>().ResetCharacter();
            col.transform.GetComponent<player1Controler>().deathCounter += 1;

            col.transform.GetComponent<player1Controler>().deathCounter += 1;
            col.transform.GetComponent<player1Controler>().tempFlapTimes = 10;

            GameObject Deathpe = SlamDownSparkPool.m_instance2.DeathPE();
            Deathpe.transform.position = col.transform.position;
            Deathpe.SetActive(true);
            RandomSpawnPoint(col);

        }
	}

    //void findPlayer(Collider2D col)
    //{
    //    for (int i = 0; i < m_players.Length; i++)
    //    {
    //        if (m_players[i].transform.position !=col.transform.position)
    //        {
    //            GameObject newObject = cherrypool.m_instance.NewObject();
    //            if (newObject != null)
    //            {
    //                newObject.transform.position = new Vector3(m_players[i].transform.position.x, m_players[i].transform.position.y + 0.6f, m_players[i].transform.position.z);
    //                newObject.transform.rotation = Quaternion.identity;
    //                newObject.GetComponent<CherrySteering>().target = m_players[i];
    //                newObject.SetActive(true);
    //            }
    //        }
    //    }
    //}

    void RandomSpawnPoint(Collider2D col)
	{
        StartCoroutine(DelayRespawn(col));
	}


    void PlayDeathSound()
    {
		m_audio.clip = m_DeathAudio;
		m_audio.volume = 1.0f;
		m_audio.Play();
    }

    IEnumerator DelayRespawn(Collider2D col)
    {
        GameObject tempObject = col.gameObject;
        tempObject.SetActive(false);
        float i = 0;
        while (i < m_RespawnDelay)
        {
            i += Time.deltaTime;
            yield return null;
        }
        int RanRan = Random.Range(0, m_SpawnPointsArray.Length);
        col.transform.root.position = m_SpawnPointsArray[RanRan].transform.position;
        col.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

        tempObject.SetActive(true);
    }
}
