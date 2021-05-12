using UnityEngine;
// handles the player moving. Not to be confused with Player manager, that handles the DATA so that the this script can use it.
public class Movement : PlayerManager
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMovePerform()
    {
        float speed = moveSpeed * ( hasMovePower ? moveSpeedMod) * Time.DeltaTime;
    }
    


}
