using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InterceptorLauncher : MonoBehaviour {

    public float speed = 2f;
    public float turningSpeed = 50f;
    public float rateOfFire = 2f;
    public List<Rigidbody> Equipped;

    private List<Transform> targets;
    private float shotDelay = 0f;

    void Awake()
    {
        targets = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0)
        {

            if (targets[0].gameObject.activeSelf == false)
            {


                targets.Remove(targets[0]);
            }
        }
        if (shotDelay <= 0)
        {
            if (targets.Count > 0)
            {
               
                    GameObject missile = PoolManager.Instance.GetObjectForType("Interceptor", false);
                    Interceptor script = missile.GetComponent<Interceptor>();
                    script.speed = speed;
                    script.turningSpeed = turningSpeed;                  
                    script.target = targets[0];
                    missile.transform.rotation = Quaternion.LookRotation(targets[0].position - transform.position);
                    missile.transform.position = transform.position;
                    shotDelay = 1 / rateOfFire;
                
            }
        }
        else
        {
            shotDelay -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Equipped.Count; i++)
        {
            if (other != Equipped[i].GetComponent<Collider>())
            {
                targets.Remove(other.transform);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < Equipped.Count; i++)
        {
            if (other != Equipped[i].GetComponent<Collider>())
            {
                targets.Remove(other.transform);
            }
        }
    }
}