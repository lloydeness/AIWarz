using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerControl : MonoBehaviour {

    public Sensor sensor;
    public List<WorkerBee> workers;
    public List<Vector3> bases;
    public List<Vector3> Minerals;

    private bool isBuilt = false;



    public
    // Use this for initialization
    void Start()
    {

    }
         


	
	// Update is called once per frame
	void Update () {

        if (isBuilt == false)
        {
            build();
            int delete = bases.Count;
            int delete2 = Minerals.Count;

        }

  
   
   
      

    }

    void build()
    {



            for (int i = 0; i < sensor.targets.Count; i++)
            {
                if (sensor.targets[i].tag == ("Mineral"))
                {
                Vector3 temp = sensor.targets[i].transform.position;
                Minerals.Add(temp);

                }
                if (sensor.targets[i].tag == ("Base"))
                {

                Vector3 temp = sensor.targets[i].transform.position;

                    bases.Add(temp);
                }

            }



            for (int i = 0; i < workers.Count; i++)
            {

                workers[i].mineralPatch = Minerals[addRandomPatch()];
                workers[i].Base = bases[0];

            }
       


        isBuilt = true;
    }

    int addRandomPatch()
    {
        float temp = Random.Range(0, Minerals.Count);


        return (int)temp;

    }

   
}


