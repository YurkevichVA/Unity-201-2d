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
        GameState.pipesPassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //body.AddForce(Vector2.right);
        if (Input.GetKeyDown(KeyCode.Space)) // �� ����������
        {
            body.AddForce(Vector2.up * Time.timeScale * forceFactor);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform parent = other.gameObject.transform.parent;
        if (parent != null && parent.gameObject.CompareTag("Pipe"))
        {
            //todo lose
        }
        else
        {
            if (other.gameObject.CompareTag("Food"))
            {
                GameState.vitality = 1;
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag("Pipe"))
        {
            GameState.pipesPassed += 1;
        }
    }
}
/* � ����� ���� �����䳿 �� ����� ��������� ���������� �� ������ �� �������
 * 
 * Գ���� ��������� "�������������" �������� �������� ������� ��� �� ��������� � ����� ����
 * 
 * ������-��������� �� ������ ������ � ������, ���� ��������� ���� OnTriggerEnter2d
 * 
 * ��䳿
 */