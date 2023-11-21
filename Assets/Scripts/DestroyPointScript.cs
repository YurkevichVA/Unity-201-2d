using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name);
        // У випадку труби колізія відбувається з її складовою частиною, тоді як знищувати треба родительський елемент
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
