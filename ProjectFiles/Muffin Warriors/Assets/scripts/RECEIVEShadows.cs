using UnityEngine;
using System.Collections;

public class RECEIVEShadows : MonoBehaviour {

    SpriteRenderer Rend;

    void Start()
    {
        Rend = GetComponent<SpriteRenderer>();
        Rend.receiveShadows = true;
    }
}
