using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized;
	}
}