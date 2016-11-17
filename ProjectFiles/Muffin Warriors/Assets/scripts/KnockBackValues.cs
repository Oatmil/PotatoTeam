using UnityEngine;
using System.Collections;

public class KnockBackValues : MonoBehaviour
{

    public Vector3 IdleAttack;
    public Vector3 CrouchAttack;
    public Vector3 AirAttack;
    public Vector3 UpAttack;
    public Vector3 Block;
    public Vector3 GetBlocked;
    public Vector3 SlamDown;


    void Start()
    {
        IdleAttack = IdleAttack * 10;
        CrouchAttack = CrouchAttack * 10;
        AirAttack = AirAttack * 10;
        UpAttack = UpAttack * 10;
        Block = Block * 10;
        GetBlocked = GetBlocked * 10;
    }
}
