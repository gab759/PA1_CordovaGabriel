using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
