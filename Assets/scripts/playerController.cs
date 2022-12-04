using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour
{
    public float movementSpeed = 10;
    public spawnManager spawnManager;
    float vMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * 5f;
        transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, Input.GetAxis("Horizontal") * 10, 0), Time.deltaTime * 10);
        if (Input.GetAxis("Vertical") >= 0)
        {
            vMovement = Input.GetAxis("Vertical") * movementSpeed;
        }
        transform.Translate(new Vector3(hMovement, 0, 10 + vMovement) * Time.deltaTime);



        //float hMovement = CrossPlatformInputManager.GetAxis("Horizontal") *5f;
        //transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, CrossPlatformInputManager.GetAxis("Horizontal")*10, 0), Time.deltaTime * 10);
        //if (Input.GetAxis("Vertical") >= 0)
        //{
        //    vMovement = CrossPlatformInputManager.GetAxis("Vertical") * movementSpeed;
        //}
        //transform.Translate(new Vector3(hMovement, 0, 10 + vMovement) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Invoke("calledAfterTwo", 2);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacles")
        {
            FindObjectOfType<gameManager>().GameOver();
        }
    }
    private void calledAfterTwo()
    {
        spawnManager.SpawnTriggerEntered();
    }
}
