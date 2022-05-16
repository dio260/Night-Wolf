using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the game object's rigidbody
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets velocity based on key inputs
        Vector2 TargetVelocity = new Vector2((Input.GetAxis("Horizontal") * speed), (Input.GetAxis("Vertical") * speed));

        //Applies velocity to player object for movement
        rBody.velocity = transform.rotation * new Vector3(TargetVelocity.x, 0, TargetVelocity.y);
    }
}
