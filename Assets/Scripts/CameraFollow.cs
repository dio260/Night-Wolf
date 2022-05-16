using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform objectFollow;
    [SerializeField] Vector3 posFromPlayer;
    [SerializeField] Vector3 camRotation;

    // Start is called before the first frame update
    void Reset()
    {
        //Gets the transform component from the selected player object
        objectFollow = GetComponentInParent<PlayerMovement>().transform;
    }

    void Start()
    {
        /*Position and rotation of camera are set
         * (Position is based on distance from the player object)
         */
        transform.position = new Vector3((objectFollow.position.x + posFromPlayer.x), 
            (objectFollow.position.y + posFromPlayer.y), (objectFollow.position.z + posFromPlayer.z));

        transform.rotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Position of camera is updated whenever the player object moves
        transform.position = objectFollow.position + posFromPlayer;
        transform.rotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
