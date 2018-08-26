// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  08/13/2018

using UnityEngine;
using UnityEngine.SceneManagement;

// Control Player movement
public class PlayerMovement : MonoBehaviour
{
    private AspectUtility aspectUtil;
    private CameraFollow cameraFollow;
    public PolygonCollider2D playerCollider;
    public Rigidbody2D rBody;
    public Scene scene;
    private SFXManager SFXMan;
    private TouchControls touches;
    private Transform trans;
    private UIManager uiMan;
    public Vector2 movementVector;

    public bool bBoosting;
    public bool bGWCUpdate;
    public bool bStopPlayerMovement;

    public float moveSpeed;


    void Start()
    {
        // Initializers
        aspectUtil = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AspectUtility>();
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        playerCollider = GetComponent<PolygonCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
        SFXMan = FindObjectOfType<SFXManager>();
        touches = FindObjectOfType<TouchControls>();
        trans = GetComponent<Transform>(); 
        uiMan = FindObjectOfType<UIManager>();

        bBoosting = false;
        bGWCUpdate = true;

        moveSpeed = 1.0f;
    }

    void Update()
    {
        if (bStopPlayerMovement)
        {
            movementVector = Vector2.zero;
            rBody.velocity = Vector2.zero;

            if (scene.name == "GuessWhoColluded")
            {
                movementVector = Vector2.zero;
                rBody.velocity = Vector2.zero;
            }
        }
        //else if (touches.bDown || touches.bLeft || touches.bRight || touches.bUp ||
        //    touches.bUpRight || touches.bUpLeft || touches.bDownRight || touches.bDownLeft)
        else if (touches.bDown || touches.bLeft || touches.bRight || touches.bUp)
        {
            // No action; just need to avoid MovePlayer() here b/c it's cancelling out
            // the Touches script by passing in Move(0,0) while touches passes Move(X,Y)
        }
        else if (scene.name == "GuessWhoColluded")
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
        else
        {
            MovePlayer();
        }

        if (scene.name == "GuessWhoColluded")
        {

        }
        else
        {
            // Set boosting
            if (Input.GetButtonDown("bAaction"))
            {
                bBoosting = true;
            }
            else if (Input.GetButtonUp("bAaction"))
            {
                bBoosting = false;
            }
        }
            
    }

    public void MovePlayer()
    {
        // Unit's Project Settings -> Input
        Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public void Move(float xInput, float yInput)
    {
        movementVector = moveSpeed * new Vector2(xInput, yInput);

        // 2x Move Speed
        if (bBoosting)
        {
            rBody.velocity = movementVector * 2;
        }
        // 1x Move Speed
        else
        {
            rBody.velocity = movementVector;
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

    public void CollisionBundle() // Note: order is important
    {
        // Reset Camera dimension / ratio incase screen size changed at all (e.g. WebGL Fullscreen)
        aspectUtil.Awake();

        // Unsync and stop camera tracking
        cameraFollow.bUpdateOn = false;

        // Hide UI (if present) and prevent input
        touches.GetComponent<Canvas>().enabled = false;
        touches.UnpressedAllArrows();

        // Prevent player movement
        bStopPlayerMovement = true;

        // Prevent player interactions (e.g. other tripwires)
        playerCollider.enabled = false;
    }
}
