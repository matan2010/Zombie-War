using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float addIntensity = 2f;
    [SerializeField] float restoreAngle = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(addIntensity);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            Destroy(gameObject);
        }
    }
}
