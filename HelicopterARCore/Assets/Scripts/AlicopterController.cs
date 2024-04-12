using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class AlicopterController : MonoBehaviour
{
    [SerializeField] private float speed;

    public GameObject Bullet;
    public Transform AtesNoktasi;
    public float AtesHizi;
    public float Sayac;

    private FixedJoystick horizontalJoystick;
    private FixedJoystick zekseni;
    private DynamicJoystick verticalJoystick;
    private Rigidbody rigidBody;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void OnEnable()
    {
        horizontalJoystick = FindObjectOfType<FixedJoystick>();
        zekseni = FindObjectOfType<FixedJoystick>();
        verticalJoystick = FindObjectOfType<DynamicJoystick>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xVal = horizontalJoystick.Horizontal;
        float yVal = verticalJoystick.Vertical;
        float zVal = zekseni.Vertical;

        // Hareket vekt�r�n� olu�tur ve h�zla �arp
        Vector3 movement = new Vector3(xVal, yVal, zVal) * speed;

        // RigidBody'ye vekt�r� uygula
        rigidBody.velocity = movement;

        // Hareket varsa helikopterin rotasyonunu g�ncelle
        if (xVal != 0 || yVal != 0 || zVal!=0)
        {
            // Hedef rotasyonu belirle
            Quaternion targetRotation = Quaternion.LookRotation(movement.normalized, Vector3.up);

            // Helikopterin rotasyonunu yumu�ak bir �ekilde g�ncelle
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * speed);
        }

        // Sesin pozisyonunu helikopterin pozisyonuna e�itle
        audioSource.transform.position = transform.position;
    }
}
