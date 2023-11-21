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
}