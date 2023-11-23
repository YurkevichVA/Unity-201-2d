using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name);
        // � ������� ����� ����� ���������� � �� ��������� ��������, ��� �� ��������� ����� ������������� �������
        var parent =
             other           // �������� (��������� ��'����)
            .gameObject     // ��'��� ����� ���������
            .transform      // ���� ��������� transform
            .parent;        // ����������� transform
                            //.gameObject;   // ��'��� ����� transform - ����������� ��'���
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
