using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Light>().intensity = Mathf.Lerp(this.GetComponent<Light>().intensity, Random.Range(2f, 4f), 2 * Time.deltaTime);
    }
}
