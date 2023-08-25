using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerInput input;

    Vector2 acceleration;
    [SerializeField] Vector2 maxAcceleration;


    void Update()
    {
        if (input.actions["Move"].IsPressed())
        {
            Vector2 value = input.actions["Move"].ReadValue<Vector2>();
            Move(value);
        }
    }

    public void Move(Vector2 value)
    {
        //acceleration += value * Time.deltaTime;
        //acceleration = new Vector2(Mathf.Clamp(acceleration.x, -maxAcceleration.x, maxAcceleration.x), Mathf.Clamp(acceleration.y, -maxAcceleration.y, maxAcceleration.y));
        //acceleration = acceleration.normalized;

        transform.position += new Vector3(value.x + acceleration.x, 0, value.y + acceleration.y) * speed * Time.deltaTime;
    }
}
