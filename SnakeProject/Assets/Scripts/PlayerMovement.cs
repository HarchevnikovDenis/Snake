using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Transform left;
    public Transform up;
    public Transform right;
    public Transform down;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 359), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);          //  Постоянное движение змейки вперед

        if(Input.GetAxis("Horizontal") != 0)                                    //  Проверка нажатий A/D
        {
            if(Input.GetAxis("Horizontal") < 0)
            {
                Vector3 direction = left.position - this.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 direction = right.position - this.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
        }

        if(Input.GetAxis("Vertical") != 0)                                    //  Проверка нажатий W/S
        {
            if(Input.GetAxis("Vertical") < 0)
            {
                Vector3 direction = down.position - this.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 direction = up.position - this.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
