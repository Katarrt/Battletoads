using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    
    RaycastHit2D raycast;
    public static bool Move=true;
    public static bool MoveLeft=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raycast = Physics2D.Raycast(this.transform.position, Vector2.down,2);
        Debug.DrawLine(this.transform.position, Vector2.down, Color.red);
        if (raycast.collider == null /* && raycast.collider.CompareTag("Platform")*/)
        {
            Move = !Move;
            //Debug.Log(Move);
        }
        //else {
        //    Move = false;
        //    Debug.Log(raycast.collider.name);

        //}
    }
}
