using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D physics;
    public float force = 10.0f;

    void Update()
    {
        physics.AddForce(Vector2.right * Input.GetAxis("Horizontal") * force);
    }
}
