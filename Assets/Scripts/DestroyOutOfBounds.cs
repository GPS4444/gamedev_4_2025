using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float bottomBound = -10;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
