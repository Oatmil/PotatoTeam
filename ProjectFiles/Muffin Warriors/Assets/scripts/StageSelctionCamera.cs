using UnityEngine;
using System.Collections;

public class StageSelctionCamera : MonoBehaviour
{
    public float InputDelay;
    float DelayTimer = 0;

    public Vector3[] m_positions;
    public Vector3[] m_rotations;

    float nextPrevious;
    int CurrentSelection = 1;

    // Update is called once per frame
    void Update()
    {
        DelayTimer += Time.deltaTime;
        if (DelayTimer > InputDelay)
        {
            nextPrevious = Input.GetAxis("Horizontal");
            if (nextPrevious > 0.1f)
            {
                ChangeLocation(1);
            }
            else if (nextPrevious < -0.1f)
            {
                ChangeLocation(2);
            }
        }
        MoveCamera();
        EnterScene();
    }

    void ChangeLocation(int choice)
    {
        if (choice == 1)
        {
            AddCurrentSelection();
        }
        if (choice == 2)
        {
            MinusCurrentSelection();
        }
        DelayTimer = 0;
    }

    void AddCurrentSelection()
    {
        if (CurrentSelection == m_positions.Length - 1)
            CurrentSelection = 0;
        else
            CurrentSelection += 1;
    }
    void MinusCurrentSelection()
    {
        if (CurrentSelection == 0)
            CurrentSelection = m_positions.Length - 1;
        else
            CurrentSelection -= 1;
    }

    void MoveCamera()
    {
        Vector3 EndPosition = m_positions[CurrentSelection];
        transform.position = Vector3.Lerp(transform.position, EndPosition, 0.1f);
        Quaternion EndRotation = Quaternion.Euler(m_rotations[CurrentSelection]);
        transform.rotation = Quaternion.Lerp(transform.rotation, EndRotation, 0.1f);
    }

    void EnterScene()
    {
        if (Input.GetButtonDown("Select"))
        {
            Application.LoadLevel("1");
        }
    }
}
