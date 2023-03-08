using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCamera : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;

    private Rigidbody2D cameraBody;
    // Start is called before the first frame update
    void Start()
    {
        cameraBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < minX)
        {
            cameraBody.velocity = new Vector2(speed, cameraBody.velocity.y);
        } 
        else if (gameObject.transform.position.x > maxX)
        {
            cameraBody.velocity = new Vector2(-speed, cameraBody.velocity.y);
        }
    }
}
