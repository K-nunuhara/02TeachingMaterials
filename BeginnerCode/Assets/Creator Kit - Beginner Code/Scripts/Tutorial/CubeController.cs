using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Rigidbody rb = null;

    public float jump_power = 5.0f;
    public float speed = 0.15f;

    public string player_name = "Unity-chan";
    public string boss_name = "Cuctus-king";

    bool dead_flag = false;
    bool is_ground = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set Rigidbody to rb
        rb = this.GetComponent<Rigidbody>();

        // Define variables
        int boss_HP = 100, boss_ATK = 20;
        int player_HP = 85, player_ATK = 65;

        // Call Attack function with variables
        boss_HP = Attack(player_name, player_ATK, boss_name, boss_HP);
        player_HP = Attack(boss_name, boss_ATK, player_name, player_HP);
        if (!dead_flag)
        {
            boss_HP = Attack(player_name, player_ATK, boss_name, boss_HP);
        }
        if (!dead_flag)
        {
            player_HP = Attack(boss_name, boss_ATK, player_name, player_HP);
        }
    }

    // Define Attack() function with variables
    int Attack(string attacker_name, int attacker_ATK, string target_name, int target_HP)
    {
        // Caluculate
        target_HP -= attacker_ATK;

        /* Output
        * If (target name != 0) and (attacker_name != boss_name)
        * It can be written if (target_HP != 0 && attacker_name != boss_name)
        */
        if (target_HP != 0)
        {
            if (attacker_name != boss_name)
            {
                Debug.Log(attacker_name + "'s attack! " + attacker_ATK + " damege!");
            }
        }

        // Check HP
        if (target_HP < 0)
        {
            target_HP = 0;
            Debug.Log(target_name + " is died...");

            // Set true to flag
            dead_flag = true;
            return 0;
        }
        else
        {
            Debug.Log("Remaining HP of " + target_name + ": " + target_HP);
            return target_HP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Variable definition for Input ( ← and → )
        float x_input = Input.GetAxis("Horizontal");

        // Variable definition for Input ( ↑ and ↓)
        float z_input = Input.GetAxis("Vertical");

        transform.position += new Vector3(x_input, 0, z_input) * speed;

        if (Input.GetKey(KeyCode.Q))
        {
            Quaternion rotation = Quaternion.Euler(0, -2, 0);
            this.transform.rotation *= rotation;
        }

        if (Input.GetKey(KeyCode.E))
        {
            Quaternion rotation = Quaternion.Euler(0, 2, 0);
            this.transform.rotation *= rotation;
        }

        if (Input.GetKeyUp(KeyCode.Space) && is_ground)
        {
            rb.velocity = new Vector3(0, jump_power, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Enter the Ground!");
            is_ground = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Exit the Ground!");
            is_ground = false;
        }
    }

}

