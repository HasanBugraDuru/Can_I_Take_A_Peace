using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertransformed : MonoBehaviour
{
    [SerializeField] private Transform changeTransform;
    [SerializeField] private float changeRange = 1.5f;
    [SerializeField] private LayerMask changableLayer;
    [SerializeField] private float Amount=5f;
    bool intransformable;
    Ability playerAbility;

    Rigidbody2D rb;
    Player player;
    Collider2D coll;
    SpriteRenderer sp;
    PlayerAttack pa;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        pa = GetComponent<PlayerAttack>();
        intransformable = false;
        playerAbility = GetComponentInChildren<Ability>();
    }

    private RaycastHit2D transformable;
    private void Update()
    {
        if (intransformable)
        {
            if (playerAbility.currentMagic <= 0)
            {
                pa.CanHit = true;
                ChangeBack();
            }
            else
            {
                playerAbility.rechargeTimer = 0f;
                playerAbility.currentMagic -= Time.deltaTime *Amount;
            }
        }
        if (UserInput.instance.controls.Transform.Transform.WasPressedThisFrame() && !intransformable)
        {
          Change();
        }else if(UserInput.instance.controls.Transform.Transform.WasPressedThisFrame() && intransformable)
        {
           ChangeBack();
        }
    }

    private void Change()
    {
        intransformable = true;
        transformable = Physics2D.CircleCast(changeTransform.position, changeRange,
            transform.right,0f,changableLayer );
        ITransformable changable =  transformable.collider.gameObject.GetComponent<ITransformable>();
        if (transformable.collider.gameObject.CompareTag("Devil"))
        {
            changable.ChangColor();
        }
        else if(changable != null && !transformable.collider.gameObject.CompareTag("Devil"))
        {
            transform.position = transformable.transform.position;
            changable.ChangColor();
            sp.enabled = false;
            print(sp.enabled);
            coll.enabled = false;
            player.enabled = false;
            rb.isKinematic = true;
        }
    }
    private void ChangeBack()
    {
        intransformable = false;
        playerAbility.isScanning = false;
        sp.enabled = true;
        coll.enabled = true;
        player.enabled = true;
        rb.isKinematic = false;
    }
}
