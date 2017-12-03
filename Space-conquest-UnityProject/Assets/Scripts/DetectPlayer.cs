using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("PlayerDetection", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GetComponent<Animator>().SetBool("PlayerDetection", true);
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponent<Animator>().SetBool("PlayerDetection", false);
    }
}
