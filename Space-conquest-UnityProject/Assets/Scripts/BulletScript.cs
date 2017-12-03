using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<lifescript>
        //{
        if (collision.gameObject.GetComponent<LifeScript>())
        {
            collision.gameObject.GetComponent<LifeScript>().Damage(5);
        }
        //
        //}
    }
    void OnParticleCollision(GameObject other)
    {
        Rigidbody body = other.GetComponent<Rigidbody>();
        if (body)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction = direction.normalized;
            body.AddForce(direction * 5);
        }
    }
}
