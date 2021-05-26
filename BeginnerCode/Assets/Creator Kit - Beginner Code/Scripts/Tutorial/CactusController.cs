using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using CreatorKitCode;

public class CactusController : MonoBehaviour
{
    public float jump_power = 5.0f;
    public float speed = 0.15f;

    public int atk = 1;
    public int atk_coldown = 1;
    public float atk_range = 2.0f;
    public bool is_attackable = true;
    public AnimationClip attack_clip;

    private Rigidbody rb = null;
    private Animator anim = null;
    private bool is_ground = false;
    private Vector3 pre_pos;

    // Start is called before the first frame update
    void Start()
    {
        // Set Rigidbody to rb
        rb = this.GetComponent<Rigidbody>();

        // Set Start position
        pre_pos = this.transform.position;

        anim = this.transform.Find("CactusNails").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        TryToAttack();
    }

    private void Move()
    {
        pre_pos = this.transform.position;
        float x_input = Input.GetAxis("Horizontal");
        float z_input = Input.GetAxis("Vertical");
        transform.position += new Vector3(x_input, 0, z_input) * speed;
        Vector3 diff_pos = this.transform.position - pre_pos;

        if (diff_pos.magnitude > 0.01f)
        {
            Quaternion target = Quaternion.LookRotation(diff_pos);
            this.transform.rotation =
                Quaternion.Slerp(this.transform.rotation, target, speed);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyUp(KeyCode.Space) && is_ground)
        {
            rb.velocity = new Vector3(0, jump_power, 0);
        }
    }

    private void Rotate()
    {
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
    }

    private void TryToAttack()
    {
        // Create Ray from current position + (0, 1, 0) to the forward direction
        Ray ray = new Ray(this.transform.position + Vector3.up, this.transform.forward);

        // Declare to get hit-target
        RaycastHit hit;

        // Set 10000000000000 as binary because LayerMask.NameToLayer("Player") == 13
        // It is same 8192 as decimal number(int)
        int targetLayerMask = 1 << LayerMask.NameToLayer("Player");

        if (Physics.Raycast(ray, out hit, atk_range, targetLayerMask) && is_attackable)
        {
            Debug.DrawRay(ray.origin, ray.direction * atk_range, Color.green, 5);
            Debug.Log("Attack!");
            // Next step«
            Attack(hit.collider.GetComponent<CharacterData>());
        }
    }

    private async void Attack(CharacterData target)
    {
        // Play attack animation
        transform.Find("CactusNails").GetComponent<Animator>().Play("Attack");
        is_attackable = false;

        // Wait finishing attack motion
        await Task.Delay((int)(attack_clip.length * 1000));

        // Check target position before damage
        Vector3 diff_pos = target.transform.position - this.transform.position;
        float collider_offset = this.GetComponent<BoxCollider>().size.z / 2f;
        if (diff_pos.sqrMagnitude < atk_range * atk_range + collider_offset)
        {
            target.Stats.ChangeHealth(this.atk * -1);
        }

        // Set attack cooldown
        await Task.Delay(atk_coldown * 1000);
        is_attackable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            is_ground = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            is_ground = false;
        }
    }

}

