using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//serving as data for player (?)
// basically the monobehaviour so you can place it on the player.
public class PlayerManager : MonoBehaviour
{
    public static float moveSpeed = 1.0f ;
    public float moveSpeedMod = 1;
    public bool hasMovePower = false;

    public static float jumpHeight =  3.0f;
    public float jumpMod = 1;
    public bool hasJumpPower = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
