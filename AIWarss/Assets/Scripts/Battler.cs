using UnityEngine;
using System.Collections;

public class Battler : SteeringBehaviour {

    public Rigidbody  rb3d;
    public Sensor sensor;
    public Sensor Lsensor;
    public Sensor Rsensor;
    public Rigidbody Enemy;
    private bool isColliding = false;


    // Use this for initialization
    void Start () {
        maxSpeed = 3;
        turnSpeed = 0.2f;
        

	
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    void FixedUpdate()
    {

        
        Wander();
        //AvoidHullCollisions(0.5f);
        if (isColliding == false)
        {
            if (sensor.targets.Count > 0)
            {

                if (sensor.targets[0].gameObject.activeSelf == false)
                {


                    sensor.targets.Remove(sensor.targets[0]);
                }
                else
                {
                    Seek(sensor.targets[0].transform.position, 0);

                }

            }
        }
        else
        {
            AdvancedCollisions(Lsensor, Rsensor);
        }
        
        ApplySteering();
        Reset();


        if (rb3d.rotation.x != 90f)
        {       
            Vector3 rot = rb3d.rotation.eulerAngles;
            rot = new Vector3(0, rot.y, rot.z);
            rb3d.rotation = Quaternion.Euler(rot);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
            {
            isColliding = true;
            }

    }

    void OnTriggerxit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            isColliding = false;
        }

    }

}
