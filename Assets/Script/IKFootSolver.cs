using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    Vector3 old_pos;
    Vector3 current_pos;
    Vector3 new_pos;
    float step_distance = 0.5f;
    float speed = 5;
    float stepHeight = 0.2f;
    float lerp = 1;
    public Transform step_point;
    public IKFootSolver[] OppositeFoot;
    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        current_pos = transform.position;
        new_pos = transform.position;
        old_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = current_pos;
        if (Vector3.Distance(new_pos, step_point.position) > step_distance)
        {
            new_pos = step_point.position;
            lerp = 0;
        }
        if (lerp < 1)
        {
            if (OppositeFoot[0].isGrounded && OppositeFoot[1].isGrounded)
            {
                Vector3 foot_pos = Vector3.Lerp(old_pos, new_pos, lerp);
                foot_pos.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;
                current_pos = foot_pos;
                lerp += Time.deltaTime * speed;
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = true;
            old_pos = new_pos;
        }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new_pos, 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(old_pos, 0.1f);
    }
}
