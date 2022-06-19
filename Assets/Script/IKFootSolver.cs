using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    Vector3 current_pos;
    // Start is called before the first frame update
    void Start()
    {
        current_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = current_pos;
    }
}
