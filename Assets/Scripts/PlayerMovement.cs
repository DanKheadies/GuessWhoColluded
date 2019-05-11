// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  05/10/2019

using UnityEngine;

// Control Player movement
public class PlayerMovement : MonoBehaviour
{
    public PolygonCollider2D playerCollider;
    public Rigidbody2D rBody;
    private TouchControls touches;
    private Transform trans;
    public Vector2 movementVector;

    public bool bBoosting;
    public bool bGWCUpdate;
    public bool bIsMobile;
    public bool bStopPlayerMovement;

    public float moveSpeed;


    void Start()
    {
        // Initializers
        playerCollider = GetComponent<PolygonCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
        touches = FindObjectOfType<TouchControls>();
        trans = GetComponent<Transform>(); 
        
        bGWCUpdate = true;

        moveSpeed = 1.0f;
    }

    void Update()
    {
        if (bStopPlayerMovement)
        {
            movementVector = Vector2.zero;
            rBody.velocity = Vector2.zero;
        }
        else if (touches.bDown ||
                 touches.bLeft ||
                 touches.bRight ||
                 touches.bUp)
        {
            // No action; just need to avoid MovePlayer() here b/c it's cancelling out
            // the Touches script by passing in Move(0,0) while touches passes Move(X,Y)
        }
        else
        {
            if (bGWCUpdate)
            {
                GWCMovePlayer();
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                bGWCUpdate = false;
            }
            else  if (Input.GetAxisRaw("Vertical") != 0)
            {
                bGWCUpdate = false;
            }
            else
            {
                bGWCUpdate = true;
            }
        }  
    }
    
    public void GWCMovePlayer()
    {
        GWCMove(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public void GWCMove(float xInput, float yInput)
    {
        if (trans.position.x == 0 && xInput < 0)
        {
            rBody.position = new Vector2(0, rBody.position.y + (2 * yInput));
        }
        else if (trans.position.x == 10 && xInput > 0)
        {
            rBody.position = new Vector2(10, rBody.position.y + (2 * yInput));
        }
        else if (trans.position.y == 0 && yInput > 0)
        {
            rBody.position = new Vector2(rBody.position.x + (2 * xInput), 0);
        }
        else if (trans.position.y == -6 && yInput < 0)
        {
            rBody.position = new Vector2(rBody.position.x + (2 * xInput), -6);
        }
        else
        {
            rBody.position = new Vector2(rBody.position.x + (2 * xInput), rBody.position.y + (2 * yInput));
        }
    }
}
