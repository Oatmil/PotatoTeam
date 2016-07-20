using UnityEngine;
using System.Collections;

public class CanvasScripts : MonoBehaviour {

    public void BringFront()
    {
        this.gameObject.transform.SetAsLastSibling();
    }
}
