using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : LifeScript {
    
    public float SpeedMovement;
    public float jumpPower;
    public float MaxSpeed;
    bool Canjump = true;
    public GameObject Flammes;
    public GameObject DeadScreen;
    private float timer = 0;
    bool IsShooting = false;
    public Text LifeCount;
    GameObject Player;
    public static bool IsInputEnabled = true;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Flammes.SetActive(false);
        SetCountText();

    }
    void FixedUpdate () {
        SetCountText();
        if (GetComponent<Rigidbody>().velocity.magnitude < MaxSpeed)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                GetComponent<Animator>().SetBool("IsWalkingForward", true);
                GetComponent<Rigidbody>().AddForce(transform.forward * SpeedMovement);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Flammes.SetActive(false);
                    IsShooting = false;
                    GetComponent<Animator>().SetBool("IsRunning", true);
                    GetComponent<Rigidbody>().AddForce(transform.forward * (SpeedMovement * 0.6f));
                }
            }
            if (Input.GetKey(KeyCode.Q))
            {
                GetComponent<Animator>().SetBool("IsWalkingLeft", true);
                GetComponent<Rigidbody>().AddForce((-transform.right * SpeedMovement));
            }
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Animator>().SetBool("IsWalkingBack", true);
                GetComponent<Rigidbody>().AddForce(-transform.forward * SpeedMovement);
            }
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Animator>().SetBool("IsWalkingRight", true);
                GetComponent<Rigidbody>().AddForce(transform.right * SpeedMovement);
            }
            if (Input.GetKeyDown(KeyCode.Space) && Canjump)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPower, 0));
            }
            if (Input.GetMouseButton(0))
            {
                Flammes.SetActive(true);
                IsShooting = true;
                timer = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            GetComponent<Animator>().SetBool("IsWalkingForward", false);
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            GetComponent<Animator>().SetBool("IsWalkingLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("IsWalkingRight", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("IsWalkingBack", false);
        }
        Canjump = false;
        if (IsShooting)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                IsShooting = false;
                Flammes.SetActive(false);
                timer = 0;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Canjump = true;
    }
    public override void Damage(int d)
    {
        base.Damage(d);
        GetComponent<Animator>().SetInteger("Pv", Pv);
        SetCountText();
        if (Pv <= 1)
        {
            DeadScreen.SetActive(true);
            Player.GetComponent<CameraController>().enabled = false;
            
            Cursor.visible = true;
            this.enabled = false;

        }
    }
    void SetCountText()
    {
        LifeCount.text = "Life: " + GetComponent<Animator>().GetInteger("Pv").ToString();
    }
}
