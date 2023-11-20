using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private Transform circleTransform;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            body.AddForce(Vector2.up * 500);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);

        // Move the object using Rigidbody2D
        GetComponent<Rigidbody2D>().velocity = new Vector2(movement.x * 2f, GetComponent<Rigidbody2D>().velocity.y);
    }
}
