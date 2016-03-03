using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

	public GameObject m_spawnPoint3;
	public GameObject m_spawnPoint2;
	public GameObject m_spawnPoint1;
	public GameObject m_DeathBoom;

	GameObject[] m_SpawnPointsArray = new GameObject[3];

	void Start()
	{
		m_SpawnPointsArray [0] = m_spawnPoint1;
		m_SpawnPointsArray [1] = m_spawnPoint2;
		m_SpawnPointsArray [2] = m_spawnPoint3;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Instantiate (m_DeathBoom, col.transform.root.position, Quaternion.identity);
		RandomSpawnPoint (col);
        col.transform.GetComponent<player1Controler>().deathCounter += 1;
	} 

	void RandomSpawnPoint(Collider2D col)
	{
		int RanRan = Random.Range (0, m_SpawnPointsArray.Length);
		col.transform.root.position = m_SpawnPointsArray[RanRan].transform.position;
	
	}
}
