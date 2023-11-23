using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name);
        // У випадку труби колізія відбувається з її складовою частиною, тоді як знищувати треба родительський елемент
        var parent =
             other           // колайдер (компонент об'єкту)
            .gameObject     // об'єкт цього колайдеру
            .transform      // його компонент transform
            .parent;        // батьківський transform
                            //.gameObject;   // об'єкт цього transform - батьківський об'єкт
        if (parent != null && parent.CompareTag("Pipe"))
        {
            GameObject.Destroy(parent.gameObject);
        }
        else
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
