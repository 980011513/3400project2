using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public float maxUpSpeed = 7f;
    public float jetpackMaxEnergy = 100f;
    public float jetpackBurnRate = 20f;
    // public float jetpackRegenRate = 10f;


    public Transform respawnCheck;
    public float respawnDistance = 0.1f;
    public LayerMask respawnMask;

    public float JetpackEnergy { get; private set; }
    Vector3 velocity;
    float jetpackTime = 0f;


    bool hasFallen = false;
    public GameObject respawnPoint;
    Vector3 position = new Vector3(-0.5f, 1.5f, 4f);

    RockBehaivior currentPlatform;

    void Start()
    {
        JetpackEnergy = jetpackMaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        //hasFallen = Physics.CheckSphere(respawnCheck.position, respawnDistance, respawnMask);
        Debug.Log("Shoould not respawn");

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (hasFallen)
        {
            controller.Move(respawnPoint.transform.position);
            Debug.Log("Should Respawn");
        }

        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jump");
        }

        if (Input.GetKey(KeyCode.LeftShift) && JetpackEnergy > 0f)
        {
            Debug.Log("Current energy: " + JetpackEnergy);
            float verticalVelocity = velocity.y;
            verticalVelocity = Mathf.Min(verticalVelocity + 200 * Time.deltaTime, maxUpSpeed);
            velocity.y = verticalVelocity;
            JetpackEnergy -= jetpackBurnRate * Time.deltaTime;
            jetpackTime += Time.deltaTime;
        }
        else if (controller.isGrounded)
        {
            Debug.Log("Current energy: " + JetpackEnergy);
            // JetpackEnergy = Mathf.Min(jetpackMaxEnergy, JetpackEnergy + jetpackRegenRate * Time.deltaTime);
        }
    }
}
