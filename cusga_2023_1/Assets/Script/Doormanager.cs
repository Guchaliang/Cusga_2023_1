using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doormanager : MonoBehaviour
{
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {

      }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

    }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                wall.SetActive(false);
                Debug.Log("yes");
            }
    }
}
