using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [SerializeField]                      // ���� [SerializeField] �� public
    private float ForceMagnitude = 10f;   // ������� ��� ���� ����� UnityEditor
                                          // ������� Editor �����������
    [SerializeField]
    private TMPro.TextMeshProUGUI CollisionsTMPro;

    private Rigidbody2D Rigidbody2D;
    private Vector2 ForceDirection;

    void Start()
    {
        Rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");  // "������", ASDW, ��������
        float inputY = Input.GetAxis("Vertical");    //

        ForceDirection = new Vector2(inputX * ForceMagnitude, inputY * ForceMagnitude);
        Rigidbody2D.AddForce(ForceDirection);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // �������� ��䳿 CollisionEnter, ��� ������ �� ������� ����������
        // ���糿 - �������� ���������. 
        // other.gameObject - ��������� �� ��'���, � ���� �������� ��������

        // Debug.Log("Collision: " + other.gameObject.name);
        CollisionsTMPro.text = (int.Parse(CollisionsTMPro.text) + 1).ToString();
        /* �.�. ���������� ��������� "����" �� ��������:
         * ���� ������� ��'��� (�����) ������ +1
         * ���� ����� ��'��� +2
         * �������� � ����� -1
         * ³��������� ���� �� ��� ��� �� �����
         */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �������� ��䳿 TriggerEnter, ��� ������ �� ������� ��������
        // ���������, �������� ���� � ���� � IsTrigger
        // ��� ��������� �� ����������� �� �������� (��'���� �� ���������)
        // � ���� �������� ���� (� ���������� ��������)
        // ���� ��������� ������ ��������, ����� ���� ������ ��������
        // ��������� (� �� IsTrigger)

        Debug.Log("Trigger: " + other.gameObject.name);

        other.gameObject.transform.position =
            new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 3.5f));
        /* �.�. �������� �� ������ �� ���� �� ���� ��'����
         * - � ��������� ����������
         * - � ������-����������
         * ����������� �������� ��������� ��� �������� � �������
         */
    }
}
