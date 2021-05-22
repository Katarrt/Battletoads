using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adasgasgha : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2.86f,-10);
    }
}
