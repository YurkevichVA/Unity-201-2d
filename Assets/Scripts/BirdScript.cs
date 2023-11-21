using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D body;
    private float forceFactor = 250f;

    private float continualForceFactor = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //body.AddForce(Vector2.right);
        if (Input.GetKeyDown(KeyCode.Space)) // на натискання
        {
            body.AddForce(Vector2.up * forceFactor);
        }
        if (Input.GetKey(KeyCode.W)) // "неперервний" - з кожен Update 
        {
            body.AddForce(continualForceFactor * Time.deltaTime * Vector2.up);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision detected" + collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger detected: " + collision.gameObject.name);
    }
}
/* З точки зору взаємодії між собою колайдери поділяються на фізичні та тригери
 * 
 * Фізичні колайдери "відпрацьовують" зіткнення засобами двигуна Юніті та передають у скріпт подію
 * 
 * Тригер-колайдери не беруть участь у двигуні, лише передають подію OnTriggerEnter2d
 * 
 * Події
 */