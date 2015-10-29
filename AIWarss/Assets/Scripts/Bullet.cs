using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Collider ignoreCollider { get; set; }

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
