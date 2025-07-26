using Unity.Mathematics;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float _MoveSpeed;
    public float _TurnSpeed;

    void Update()
    {

        Move();
        Turn();

    }

    void Move()
    {
        //à⁄ìÆ
        if (Input.GetKey(KeyCode.W))
        {
            var front = transform.forward;
            transform.position += _MoveSpeed * front * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            var front = transform.forward;
            transform.position += -_MoveSpeed * front * Time.deltaTime;
        }
    }

    void Turn()
    {
        //âÒì]èâä˙âª
        float xRotation = 0f;
        float yRotation = 0f;

        //âÒì]
        if (Input.GetKey(KeyCode.UpArrow))
        {
            xRotation = -_TurnSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            xRotation = _TurnSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            yRotation = -_TurnSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            yRotation = _TurnSpeed * Time.deltaTime;
        }

        Quaternion deltaRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.rotation = deltaRotation * transform.rotation;
    }
}
