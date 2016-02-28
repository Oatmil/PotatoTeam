using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.root != transform.root && col.tag != "Ground" && !col.isTrigger) // see if you did not hit self or ground
        {   
            if (!col.transform.root.GetComponent<player1Controler>().damage) // see if he can take damage or not
            {
                if (col.transform.root.GetComponent<player1Controler>().horizontal * col.transform.root.localScale.x < -0.2f)
                {
                    col.transform.root.root.GetComponent<player1Controler>().block = true;
                    Debug.Log("block");
                }
                else
                {
                    Debug.Log("hit");
                    col.transform.root.GetComponent<player1Controler>().damage = true;
                    col.transform.root.GetComponentInChildren<Animator>().SetTrigger("Damage");
                    GameObject newObject = hitsparkpool.m_instance.NewObject();
                    if (newObject != null)
                    {
                        newObject.transform.position = new Vector3 ( col.transform.position.x,col.transform.position.y + 0.6f, col.transform.position.z);
                        newObject.transform.rotation = Quaternion.identity;
                        newObject.SetActive(true);
                    }
                }
            }
        }
    }

}
