using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMedicalBox : MonoBehaviour {
    GameObject Player;
    private void Start()
    {
       Player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Debug.Log("player takes health");
            var Pv = Player.GetComponent<Animator>().GetInteger("Pv");
            Player.GetComponent<Animator>().SetInteger("Pv", (Pv += 200));
        }
    }
}
