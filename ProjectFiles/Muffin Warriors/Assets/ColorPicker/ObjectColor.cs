using UnityEngine;
using System.Collections;

public class ObjectColor : MonoBehaviour {

	void OnSetColor(Color color)
	{
		Material mt = new Material(GetComponent<Renderer>().sharedMaterial);
		mt.color = color;
		GetComponent<Renderer>().material = mt;
	}

	void OnGetColor(ColorPicker picker)
	{
		picker.NotifyColor(GetComponent<Renderer>().material.color);
	}

    void SetLight(Color color)
    {
        Light lit = GetComponent<Light>();
        lit.color = color;
    }

    void GetLight(ColorPicker picker)
    {
        picker.NotifyColor(GetComponent<Light>().color);
    }
}
