using UnityEngine;
using System.Collections;

public class CherrySteering : MonoBehaviour {

    public GameObject target;

    public float Accel;
    Vector3 attraction;
    Vector3 velocity;

    Vector3 momentum;
    public float mass;
    Vector3 lastPos;

    public float AvoidRadius;
    GameObject[] Cherry;
    Vector3 avoidArea;
    Vector3 pushVector;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float TempX = target.transform.position.x - transform.position.x;
        float TempY = target.transform.position.y - transform.position.y + 1.5f;
        float TempZ = target.transform.position.z - transform.position.z + 1f;
        attraction = new Vector3(TempX, TempY, TempZ);

        velocity = (transform.position - lastPos).normalized;
        lastPos = transform.position;

        momentum = velocity * mass;

        Cherry = GameObject.FindGameObjectsWithTag("Cherry");
        pushVector = Vector3.zero;

        for (int i = 0; i < Cherry.Length; i++)
        {
            avoidArea = transform.position - Cherry[i].transform.position;
            if (avoidArea.magnitude < AvoidRadius)
            {

                pushVector += avoidArea;
            }
        }

        transform.position += (attraction.normalized + velocity + momentum + pushVector / 3) * Accel * Time.deltaTime;
    }

}
