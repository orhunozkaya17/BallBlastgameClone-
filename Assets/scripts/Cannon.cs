using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;
    [SerializeField] HingeJoint2D[] whell;
    [SerializeField] float speed;

    bool isMoving;
    JointMotor2D motor;
    
    Vector2 pos;
    float screenBounds;
    
 
    void Start()
    {
        motor = whell[0].motor;
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Game.Instance.screenWitdht - 0.56f;
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = Input.GetMouseButton(0);
        if (isMoving)
        {
            pos.x = cam.ScreenToWorldPoint(Input.mousePosition).x;
        }
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.MovePosition(Vector2.Lerp(rb.position, pos, speed*Time.fixedDeltaTime));
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        //rotate Whell
        float velocityX = rb.velocity.x;
        if (Mathf.Abs(velocityX)>0.0f && Mathf.Abs(rb.position.x)<screenBounds)
        {
            motor.motorSpeed = velocityX * 1500;
            MotorActivate(true);
        }
        else
        {
            motor.motorSpeed = 0f;
            MotorActivate(false);
        }
    }
    void MotorActivate(bool isActive)
    {
        whell[0].useMotor = isActive;
        whell[1].useMotor = isActive;
        whell[0].motor = motor;
        whell[1].motor = motor;
    }
}
