using UnityEngine;
using System.Collections;

public class Interceptor : MonoBehaviour {

    public Transform target { get; set; }
    public float speed { get; set; }
    public float turningSpeed { get; set; }
    public Collider ignoreCollider { get; set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate the direction from the current position to the target
        Vector3 targetDirection = target.position - transform.position;
        // Calculate the rotation required to point at the target
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        // Rotate from the current rotation towards the target rotation, but not
        // faster than mRotationSpeed degrees per second
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);
        // Move forward
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != ignoreCollider)
        {
            PoolManager.Instance.PoolObject(gameObject);
            if (other.tag == ("Player"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}