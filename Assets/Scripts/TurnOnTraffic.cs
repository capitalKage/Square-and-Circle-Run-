using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTraffic : MonoBehaviour
{
    public GameObject trafficPiece;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            trafficPiece.SetActive(true);
    }
}
