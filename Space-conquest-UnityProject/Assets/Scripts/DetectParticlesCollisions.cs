using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectParticlesCollisions : MonoBehaviour
{
    //Color colordmg = (10f, )
    int NbParticlesCollision = 0;
    // Use this for initialization
    private void OnParticleCollision(GameObject other)
    {
        NbParticlesCollision++;
            if (other.gameObject.GetComponent<LifeScript>())
            {
                other.gameObject.GetComponent<LifeScript>().Damage(1);
               //other.gameObject.GetComponent<Color>
            }
    }
}
