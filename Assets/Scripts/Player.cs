using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : BaseStatus
{
    public enum EItemType
    {
        RAKE,
        AXE,
        PICK,
        NONE
    }

    [SerializeField] private GameObject[] weapons;
    [SerializeField] private LayerMask whatisGround;
    [SerializeField] private GameObject curObject;
    [SerializeField] private EItemType necessaryItem;

    private float x_input, z_input;
    private bool isdash, isWeapon,isZoom;
    private int inven_num = 0;

    private Rigidbody rb;
    private Ray camerRay;
    private RaycastHit hit;
    
    private Inventory inven;
    private BaseWeapon curWeapon;
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

        if(Input.GetButtonDown("Fire1"))
        {
            if(isWeapon == true)
            {
                Fire();
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (curObject != null)
            {
                Interaction();
            }
        }

        for(int i = 0; i< keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                if (inven_num == i) return;
                inven_num = i;
                
                UseInven();
            }
        }     
    }
    
    private void Fire()
    {
        if (curWeapon.GetBulletAmount())
            curWeapon.Shot();
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

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        if (inven.slotsBig[inven_num].item.itemType == ITEM_TYPE.EQUIPMENT)
        {
            isWeapon = true;
            

            switch (inven.slotsBig[inven_num].itemName)
            {
                case "Gun":
                    weapons[0].SetActive(true);
                    curWeapon = weapons[0].GetComponent<Gun>();
                    necessaryItem = EItemType.NONE;
                    break;
                case "Bow":
                    weapons[1].SetActive(true);
                    curWeapon = weapons[1].GetComponent<Bow>();
                    necessaryItem = EItemType.NONE;
                    break;
                case "Axe":
                    necessaryItem = EItemType.AXE;
                    break;
                case "Rake":
                    necessaryItem = EItemType.RAKE;
                    break;
                case "Pick":
                    necessaryItem = EItemType.PICK;
                    break;

            }
        }
        else
        {
            isWeapon = false;
            necessaryItem = EItemType.NONE;
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

    private void Interaction()
    {
        curObject.SendMessage("Interaction", necessaryItem);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Building"))
        {
            curObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (curObject != null)
            curObject = null;
    }


}
