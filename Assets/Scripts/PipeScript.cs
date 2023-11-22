using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private float pipeSpeed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(pipeSpeed * Time.deltaTime * Vector3.left);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision detected: " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detected: " + collision.gameObject.name);
    }
}