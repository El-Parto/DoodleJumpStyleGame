using UnityEngine;
using UnityEngine.InputSystem;
// handles the player moving. Not to be confused with Player manager, that handles the DATA so that the this script can use it.

/*
[RequireComponent(typeof(CapsuleCollider), typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class Movement : Scoring
{


    private Rigidbody2D playerRB;
    private CapsuleCollider2D capColl2D;
    
    private Vector2 movement = Vector2.zero;

    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public InputActionReference fastFallAction;

    public bool isFastFalling = false;


    private Vector3 velocity = Vector3.zero;

    public static float moveSpeed = 1.0f;
    public float moveSpeedMod = 1;
    public bool hasMovePower = false;

    // private bool fastFallActive = false;

    public static float jumpHeight = 3.0f;
    public float jumpMod = 1;
    public bool hasJumpPower = false;
    public bool onGround = true; //may or may not use this depending on rigid system or new input system



    // Start is called before the first frame update
    void Start()
    {
        // playerRB = gameObject.GetComponent<Rigidbody2D>();
        //specifying collider
        capColl2D = gameObject.GetComponent<CapsuleCollider2D>();
        //specifying rigidbody
        playerRB = gameObject.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += movement;
        movement = Vector3.zero;
    }

    public void OnMovePerform()
    {
        float speed = moveSpeed;

        Vector2 value = moveAction.action.ReadValue<Vector2>();
        movement = transform.right * value.y * speed;


    }
    


}
*/