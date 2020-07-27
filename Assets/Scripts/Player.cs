using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Joystick stick;
    public float speed = 10f;

    //To manage movement limits
    private float minX, maxX, minY, maxY;
    private bool allowMovLeft = true;
    private bool allowMovRight = true;
    private bool allowMovTop = true;
    private bool allowMovBot = true;
    private float playerRadius;

    /* Shoot Management */
    public float shootingStartDelay, shootingInterval;
    public Transform firePointUpLeft;
    public Transform firePointUpRight;

    public GameObject bulletUpLeft;
    public GameObject bulletUpRight;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        InvokeRepeating("DefectShooting", shootingStartDelay, shootingInterval);
        //To manage movement limits
        StartMovement();
    }

    // Update is called once per frame
    void Update()
    {
        MovementManagment();
    }
    void DefectShooting()
    {
        Instantiate(bulletUpLeft, firePointUpLeft.position, firePointUpLeft.rotation);
        Instantiate(bulletUpRight, firePointUpRight.position, firePointUpRight.rotation);
    }
    void StartMovement()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x + playerRadius;
        maxX = topCorner.x - playerRadius;
        minY = bottomCorner.y + playerRadius;
        maxY = topCorner.y - playerRadius;
    }
    void MovementManagment()
    {
        allowMovLeft = true;
        allowMovRight = true;
        allowMovBot = true;
        allowMovTop = true;

        Vector3 pos = transform.position;

        if (pos.x < minX) allowMovLeft = false;
        if (pos.x > maxX) allowMovRight = false;
        if (pos.y < minY) allowMovBot = false;
        if (pos.y > maxY) allowMovTop = false;

        float horizontal = stick.Horizontal;
        float vertical = stick.Vertical;

        if (!allowMovLeft && horizontal < 0) horizontal = 0;
        if (!allowMovRight && horizontal > 0) horizontal = 0;
        if (!allowMovBot && vertical < 0) vertical = 0;
        if (!allowMovTop && vertical > 0) vertical = 0;


        Vector3 move = new Vector3(horizontal, vertical, 0);
        controller.Move(move * Time.deltaTime * speed);
    }
}
