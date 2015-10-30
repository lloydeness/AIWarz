using UnityEngine;
using System.Collections;

public class Battler : SteeringBehaviour {

    private Rigidbody  rb3d;
    public Sensor sensor;
    public Sensor Lsensor;
    public Sensor Rsensor;
    public Rigidbody Enemy;
   


    // Use this for initialization
    void Start () {
        maxSpeed = 3;
        turnSpeed = 0.2f;
        rb3d = this.GetComponentInParent<Rigidbody>();
        

	
	}
	
	// Update is called once per frame
	void Update () {


    }

    void FixedUpdate()
    {


        

        if (Lsensor.isColliding == false && Rsensor.isColliding == false)

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
        if (Lsensor.isColliding == true || Rsensor.isColliding == true)
        {
            AdvancedCollisions(Lsensor, Rsensor);
        }


        if (Lsensor.isColliding == false && Rsensor.isColliding == false && sensor.targets.Count == 0)
        {
            Wander();
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



}
