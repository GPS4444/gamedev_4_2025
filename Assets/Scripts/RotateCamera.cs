using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    void Start()
    {
        
    }
    void Update()
    {
        float horizonatlInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizonatlInput);
    }
}
