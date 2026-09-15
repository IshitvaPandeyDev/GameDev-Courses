using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Driver : MonoBehaviour
{
    [SerializeField] float CurrentSpeed = 10f;
    [SerializeField] float SteeringSpeed = 200f;
    [SerializeField] float BoostSpeed = 5f;
    [SerializeField] float RegularSpeed = 10f;

    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveamount = move * CurrentSpeed * Time.deltaTime;
        float steeramount = steer * SteeringSpeed * Time.deltaTime;

        transform.Translate(0, moveamount, 0);
        transform.Rotate(0, 0, steeramount);



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            CurrentSpeed = BoostSpeed * RegularSpeed;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        CurrentSpeed = RegularSpeed;

    }
}