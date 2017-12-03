using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour {

    public int Pv;

	void Start () {
		
	}
	public virtual void Damage (int dmg)
    {
        Pv -= dmg;
    }
    
}
