using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Ability : MonoBehaviour

{
    [SerializeField] float maxMagic;
    [SerializeField] float currentMagic;
    [SerializeField] float rechargeTimer;
    [SerializeField] bool isScanning;
     

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
            rechargeTimer += Time.deltaTime;
            if (rechargeTimer > 3)
                currentMagic += 10 * Time.deltaTime;
        }

        if (currentMagic > maxMagic)
            currentMagic = maxMagic;
        if (currentMagic < 0)
            currentMagic = 0;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("vision")&&isScanning &&currentMagic>0)
        {
            collision.GetComponent<Light2D>().intensity = 2f;
            currentMagic -= Time.deltaTime * 10f;
            Debug.Log("Seeing");
        }
        else if(collision.GetComponent<Light2D>()!=null)
            collision.GetComponent<Light2D>().intensity = 0f;

        

    }

}
