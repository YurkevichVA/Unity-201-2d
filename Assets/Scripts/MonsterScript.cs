using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private float monsterSpeed = 1.5f;

    void Update()
    {
        transform.Translate(monsterSpeed * Time.deltaTime * Vector3.left);
    }
}
