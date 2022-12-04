using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesMovement : MonoBehaviour
{
    Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("/Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - Player.position.z < 70)
        {
            transform.Translate(new Vector3(0, 0, 7) * Time.deltaTime);
        }
    }
}
