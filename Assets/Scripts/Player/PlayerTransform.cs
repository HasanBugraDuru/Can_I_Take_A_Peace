using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    SpriteRenderer sp;
    Collider2D col;
    Player player;
    Rigidbody2D rb;

    [SerializeField] private Transform transferTransform;
    [SerializeField] private float transRange = 1.5f;
    [SerializeField] private LayerMask transferableLayer;
    private RaycastHit2D trans;

    private void Update()
    {
        if (UserInput.instance.controls.Transform.Transform.WasPressedThisFrame())
        {
            Transform();
        }
    }


    private void Transform()
    {
        trans = Physics2D.CircleCast(transferTransform.position,
            transRange, transform.right, 0f, transferableLayer);

     
        ITransformable transformable = trans.collider.gameObject.GetComponent<ITransformable>();
        if (transformable != null)
        {
            print("Dönüþ");
        }
         
    }
}
