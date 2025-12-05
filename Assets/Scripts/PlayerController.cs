using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerup;

    [SerializeField] float speed;
    [SerializeField] float powerupStrenght;
    [SerializeField] float PowerupLenght;
    [SerializeField] GameObject powerupIndicator;

    private void OnCollisionEnter(Collision collision)
    {
        //enemy collision with powerup
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //powerup
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    //countwown
    private IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(PowerupLenght);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);

    }
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {   
        //move
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(speed * forwardInput * focalPoint.transform.forward);
    }
}
