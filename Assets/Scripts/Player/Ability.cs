using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Ability : MonoBehaviour

{
    [SerializeField] float maxMagic;
    [SerializeField] public float currentMagic;
    [SerializeField] public float rechargeTimer;
    [SerializeField] public bool isScanning;
    [SerializeField] Image AbilityBar;
    [SerializeField] private float Amount = 5f;

    // Start is called before the first frame update
    void Start()
    {
        maxMagic = 100f;
        currentMagic = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (UserInput.instance.controls.Attack.Scan.WasPressedThisFrame())
        {
            isScanning = true;
            rechargeTimer = 0f;
            Debug.Log("isScanning");
        }
        if (UserInput.instance.controls.Attack.Scan.WasReleasedThisFrame())
        {
            isScanning = false;
        }

        if (isScanning == false)
        {
            
            if (rechargeTimer >= 3)
            {
                currentMagic += 10f * Time.deltaTime;
            }
            else
            {
                rechargeTimer += Time.deltaTime;
            }
                
        }

        if (currentMagic > maxMagic)
            currentMagic = maxMagic;
        if (currentMagic < 0)
            currentMagic = 0;
        AbilityBar.fillAmount = currentMagic / maxMagic;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("vision")&&isScanning &&currentMagic>0)
        {
            collision.GetComponent<Light2D>().intensity = 2f;
            currentMagic -= Time.deltaTime * Amount;
            Debug.Log("Seeing");
        }
        else if(collision.GetComponent<Light2D>()!=null)
            collision.GetComponent<Light2D>().intensity = 0f;

        

    }

}
