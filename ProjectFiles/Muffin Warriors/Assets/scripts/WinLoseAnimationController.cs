using UnityEngine;
using System.Collections;

public class WinLoseAnimationController : MonoBehaviour {
    Animator anim;
    public bool Win;
    public bool Lose;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Win == true)
        {
            anim.SetTrigger("Win");
            Win = false;
        }
        if (Lose == true)
        {
            anim.SetTrigger("Lose");
            Lose = false;
        }
	}
}
