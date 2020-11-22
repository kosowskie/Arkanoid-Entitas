using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    
    [SerializeField]
    float Speed = 5f;

    [SerializeField]
    float MaxPosition = 5f;

	void Start ()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate ()
    {
        var targetSpeed = Vector3.zero;

		if(Input.GetKey(KeyCode.LeftArrow))
            targetSpeed = Vector3.left;

        else if(Input.GetKey(KeyCode.RightArrow))
            targetSpeed = Vector3.right;

        Rigidbody.velocity = targetSpeed * Speed;

        var positionX = Mathf.Clamp(transform.position.x, -MaxPosition, MaxPosition);
        transform.position = new Vector3(positionX, transform.position.y);
    }
}
