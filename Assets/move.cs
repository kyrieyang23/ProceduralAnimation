using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class move : MonoBehaviour
{
    Rigidbody rigid;
    public float movementSpeed = 1.5f;
    public Transform[] FootTransform;
    Vector3 avgPosition;
    Vector3 prevAvgPosition;
    Vector3 currentPosition;
    float fowardMove;
    bool isRotate = false;
    private void Start() {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        currentPosition = transform.position;
        prevAvgPosition = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        MovementInput();  
        HandleMovement();
        
    }

    void MovementInput()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        fowardMove = 0;
        isRotate = false;
        if (Input.GetKey(KeyCode.W))
        {
            fowardMove =  movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            fowardMove = -movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isRotate = true;
            rigid.angularVelocity = -transform.up * movementSpeed; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            isRotate = true;
            rigid.angularVelocity = transform.up * movementSpeed;
        }
    }

    void HandleMovement()
    {
        avgPosition = Vector3.zero;
        for(int i = 0; i < FootTransform.Length; i++)
        {
            avgPosition += FootTransform[i].position;
        }
        avgPosition = avgPosition/FootTransform.Length;
        if(avgPosition != prevAvgPosition)
        {
            prevAvgPosition = avgPosition;
            if(!isRotate)
            {
                currentPosition = (avgPosition - Vector3.Scale(transform.forward, avgPosition)) + Vector3.Scale(transform.forward, currentPosition);
            }
            else
            {
                currentPosition = avgPosition;
            }
        }
        currentPosition += transform.forward * fowardMove * Time.deltaTime;
        transform.position = currentPosition;
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(currentPosition, 0.1f);
        // Gizmos.color = Color.yellow;
        // Gizmos.DrawSphere(FootTransform[0].localPosition, 0.1f);
        // Gizmos.DrawSphere(FootTransform[1].localPosition, 0.1f);
        // Gizmos.DrawSphere(FootTransform[2].localPosition, 0.1f);
        // Gizmos.DrawSphere(FootTransform[3].localPosition, 0.1f);
    }
}
