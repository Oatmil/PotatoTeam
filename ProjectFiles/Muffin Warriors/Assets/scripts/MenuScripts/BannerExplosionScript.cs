using UnityEngine;
using System.Collections;

public class BannerExplosionScript : MonoBehaviour {
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EndAnim()
    {
        gameObject.SetActive(false);
    }
}
