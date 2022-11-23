using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speedMultiplier = 7f;
    public float rotationMultiplier = 165f;

    float hAxisInput;
    float vAxisInput;
    Rigidbody objRB;

    void Start()
    {
        objRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vAxisInput = -(Input.GetAxis("Vertical")) * speedMultiplier;
        hAxisInput = Input.GetAxis("Horizontal") * rotationMultiplier;
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hAxisInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        objRB.MovePosition(this.transform.position + this.transform.forward * vAxisInput * Time.fixedDeltaTime);
        objRB.MoveRotation(objRB.rotation * angleRot);
    }
}
