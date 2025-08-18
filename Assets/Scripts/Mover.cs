using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _movementSpeed;

    public void Rotate(float rotation)
    {
        transform.Rotate(rotation * (_rotateSpeed * Time.deltaTime) * Vector3.up);
    }

    public void Move(float direction)
    {
        float distance = direction * (_movementSpeed * Time.deltaTime);

        transform.Translate(distance * Vector3.forward);
    }
}
