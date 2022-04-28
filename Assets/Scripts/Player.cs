using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseStatus
{
    [SerializeField] private LayerMask whatisGround;

    private float x_input, z_input;
    private bool isdash;
    private int inven_num = 0;

    private Rigidbody rb;
    private Ray camerRay;
    private RaycastHit hit;

    private Inventory inven;
    private KeyCode[] keyCodes =
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6,
        KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9,
    };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inven = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckDash();
    }

    private void FixedUpdate()
    {
        CheckLookAt();
        CheckApplay();
    }

    private void CheckInput()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        z_input = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            if (hp <= 0) return;

            isdash = true;
        }
        else
        {
            isdash = false;
        }

        for(int i = 0; i< keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                inven_num = i;
                UseInven();
            }
        }
        

    }
    
    private void CheckDash()
    {
        if(isdash)
        {
            hp -= Time.deltaTime;
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }
    }

    private void UseInven()
    {
        if(inven.slotsBig[inven_num].item.itemType == ITEM_TYPE.EQUIPMENT)
        {
            Debug.Log("Use");
        }
    }

    private void CheckApplay()
    {
        rb.velocity = new Vector3(x_input, rb.velocity.y, z_input).normalized * speed;
    }

    private void CheckLookAt()
    {
        
        camerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(camerRay, out hit))
        {
            Vector3 mouseDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.forward = mouseDir;
        }
    }

  


}
