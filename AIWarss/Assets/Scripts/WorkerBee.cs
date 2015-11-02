using UnityEngine;
using System.Collections;

public class WorkerBee : SteeringBehaviour
{


    private Rigidbody rb3d;
    public Sensor SeekSensor;
    public Sensor sensor;
    public Sensor Lsensor;
    public Sensor Rsensor;
    public Sensor hitSensor;
    private Vector3 mineralPatch = new Vector3(0f,0f,0f);
    private Vector3 Base = new Vector3(0f, 0f, 0f);
    private float timeStamp = 0;



    private bool collecting = false;
    private bool hasMineral = false;
  
    public int hitPoints = 4;



    // Use this for initialization
    void Start()
    {
        maxSpeed = 3;
        turnSpeed = 0.2f;
        rb3d = this.GetComponentInParent<Rigidbody>();

 


        }

    // Update is called once per frame
    void Update()
    {
        int alive = 0;
        if (hitSensor.isColliding == true)
        {
            alive = hitPoints - hitSensor.targets.Count;

        }

        if (alive < 0)
        {
            rb3d.gameObject.SetActive(false);

        }

    }

    void FixedUpdate()
    {



        if (SeekSensor.isColliding == true)
        {
            

            if (hasMineral == false)
            {
                
                for (int i = 0; i < SeekSensor.targets.Count; i++)
                {
                    if (SeekSensor.targets[i].tag == ("Mineral"))
                    {
                        
                        Seek(SeekSensor.targets[i].transform.position, 0);
                        break;
                    }
                }

            }
            else
            {

                for (int i = 0; i < SeekSensor.targets.Count; i++)
                {
                    if (SeekSensor.targets[i].tag == ("Base"))
                    {
                        Seek(SeekSensor.targets[i].transform.position, 0);
                        break;
                    }
                }


            }


        }

        /*
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
        */

        if (collecting == true)
        {
            isCollecting();

        }
        else
        { 

        ApplySteering();
        Reset();
        }

        if (rb3d.rotation.x != 90f)
        {
            Vector3 rot = rb3d.rotation.eulerAngles;
            rot = new Vector3(0, rot.y, rot.z);
            rb3d.rotation = Quaternion.Euler(rot);
        }


    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == ("Base"))
            {
            hasMineral = false;
            }

        if (target.gameObject.tag == ("Mineral"))
        {
            hasMineral = true;
            collecting = true;
            timeStamp = Time.time;
        }

    }

    void isCollecting()
    {
        if (Time.time > timeStamp + 5)
        {
            collecting = false;

        }

    }



}