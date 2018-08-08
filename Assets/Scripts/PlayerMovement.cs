// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  07/31/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

// Control Player movement and overworld transition areas
public class PlayerMovement : MonoBehaviour
{
    //public Animator anim;
    private AspectUtility aspectUtil;
    private CameraFollow cameraFollow;
    public PolygonCollider2D playerCollider;
    public Rigidbody2D rBody;
    public Scene scene;
    private SFXManager SFXMan;
    private TouchControls touches;
    private UIManager uiMan;
    public Vector2 movementVector;

    public bool bStopPlayerMovement;
    public bool bBoosting;

    public float moveSpeed;


    void Start()
    {
        // Initializers
        //anim = GetComponent<Animator>();
        aspectUtil = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AspectUtility>();
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        playerCollider = GetComponent<PolygonCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
        SFXMan = FindObjectOfType<SFXManager>();
        touches = FindObjectOfType<TouchControls>();
        uiMan = FindObjectOfType<UIManager>();

        bBoosting = false;

        moveSpeed = 1.0f;
    }

    void Update()
    {
        if (bStopPlayerMovement)
        {
            movementVector = Vector2.zero;
            rBody.velocity = Vector2.zero;
        }
        else if (touches.bDown || touches.bLeft || touches.bRight || touches.bUp)
        {
            // No action; just need to avoid MovePlayer() here b/c it's cancelling out
            // the Touches script by passing in Move(0,0) while touches passes Move(X,Y)
        }
        else
        {
            MovePlayer();
        }

        // Set boosting
        if (Input.GetButtonDown("BAction"))
        {
            bBoosting = true;
        }
        else if (Input.GetButtonUp("BAction"))
        {
            bBoosting = false;
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

        // Animate movement
        //if (movementVector != Vector2.zero)
        //{
        //    anim.SetBool("bIsWalking", true);
        //    anim.SetFloat("Input_X", movementVector.x);
        //    anim.SetFloat("Input_Y", movementVector.y);
        //}
        //else
        //{
        //    anim.SetBool("bIsWalking", false);
        //}

        // 2x Move Speed
        if (bBoosting)
        {
            rBody.velocity = movementVector * 2;
            //anim.speed = 2.0f;
        }
        // 1x Move Speed
        else
        {
            rBody.velocity = movementVector;
            //anim.speed = 1.0f;
        }
    }

    public void CollisionBundle() // Note: order is important
    {
        // Reset Camera dimension / ratio incase screen size changed at all (e.g. WebGL Fullscreen)
        aspectUtil.Awake();

        // "Stop" player animation
        //anim.speed = 0.001f;

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

    // Location triggers, camera sliding, player stop/start, player sliding, faders, & sound effects
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Overworld Warps
        if (collision.CompareTag("Door"))
        {
            SFXMan.sounds[0].PlayOneShot(SFXMan.sounds[0].clip);
            collision.gameObject.transform.localScale = Vector3.zero;
        }
    }
}
