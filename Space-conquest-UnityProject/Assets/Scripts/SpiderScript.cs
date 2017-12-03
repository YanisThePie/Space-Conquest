using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PostProcessing;

public class SpiderScript : LifeScript {

    public float Speed;
    public Transform Destination;
    private Transform Dest;
    private NavMeshAgent agent;
    private float timer = 0;
    GameObject Player;
    public PostProcessingProfile DamagedCam;
    private PostProcessingProfile NormalCam;
    public GameObject Hammer;
    public GameObject DmgPrefab;
    int PvTmp;
    int PvForDisable;
    int cpt;
    public int dmg;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        Dest = this.transform;
        agent.destination = Dest.position;
        Player = GameObject.FindWithTag("Player");
        NormalCam = Camera.main.GetComponent<PostProcessingBehaviour>().profile;
        PvTmp = Pv;
        cpt = 0;
        dmg = 4;
    }

    public override void Damage (int d)
    {
        if (Pv <= (PvTmp - 10))
        {
            InstantiateDmg();
            PvTmp = Pv;
        }
            base.Damage(d);
        GetComponent<Animator>().SetInteger("Pv", Pv);
    }
    void InstantiateDmg()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            DmgPrefab,
            ((this.transform.position) + new Vector3(0, 2, 0)),
            this.transform.rotation);

        // Add velocity to the bullet
        bullet.transform.Translate(Vector3.up, Space.World);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.up * 6;

        // Destroy the bullet after 0.5 seconds
        Destroy(bullet, 0.5f);
    }
    // Use this for initialization

    // Update is called once per frame
    void FixedUpdate () {
        PvForDisable = GetComponent<Animator>().GetInteger("Pv");
        agent.destination = Dest.position;
        if (agent.remainingDistance <= 5.4)
        {
            if (Dest == Destination)
            {
                timer += Time.deltaTime;
                GetComponent<Animator>().SetBool("CanAttackPlayer", true);
                if (timer >= 1)
                {
                    Player.GetComponent<PlayerScript>().Damage(dmg);
                    Camera.main.GetComponent<PostProcessingBehaviour>().profile = DamagedCam;
                        
                }
                if (timer >= 1.3)
                {
                    Camera.main.GetComponent<PostProcessingBehaviour>().profile = NormalCam;
                    timer = 0;
                }
            }
         GetComponent<Animator>().SetBool("IsWalking", false);
        }
        if (agent.remainingDistance > 5.4)
        {
            Camera.main.GetComponent<PostProcessingBehaviour>().profile = NormalCam;
            GetComponent<Animator>().SetBool("IsWalking", true);
         GetComponent<Animator>().SetBool("CanAttackPlayer", false);
        }
        if (Pv <= 0)
        {
            GameObject hmer;
            Camera.main.GetComponent<PostProcessingBehaviour>().profile = NormalCam;
            if (cpt == 0)
            {
                hmer = Instantiate(Hammer, this.transform.position, this.transform.rotation);
                hmer.transform.Translate(Vector3.up, Space.World);
                cpt += 1;
            }
            agent.enabled = false;
            Destroy(this.gameObject, 5.0f);
           this.enabled = false;
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Dest = Destination;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            float x = Random.Range(-40, 66);
            float y = -16.27f ;
            float z = Random.Range(40, 95);
            var randomPos = new Vector3(x, y, z);
            agent.destination = randomPos;
        }
    }
}