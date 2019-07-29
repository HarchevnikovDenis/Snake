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
    [SerializeField]
    private GameObject tailPrefab;
    private bool canJump;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 359), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);          //  Постоянное движение змейки вперед

        if(Input.GetAxis("Horizontal") != 0f)                                    //  Проверка нажатий A/D
        {
            if(Input.GetAxis("Horizontal") < 0f)
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

        if(Input.GetAxis("Vertical") != 0f)                                    //  Проверка нажатий W/S
        {
            if(Input.GetAxis("Vertical") < 0f)
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

        /*if(Input.GetAxis("Jump") != 0f && canJump)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 4f, ForceMode.Impulse);
        }*/
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Apple")                                 //Змейка съела яблоко
        {
            StopCoroutine("AddTail");
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.GetComponent<Animator>().SetTrigger("IsEat");
            Material Mat = other.gameObject.GetComponent<MeshRenderer>().material;
            Destroy(other.gameObject.transform.parent.gameObject, 2f);
            GameManager.Instance.score = GameManager.Instance.tails.Count;
            StartCoroutine("AddTail", Mat);
        }
    }

    IEnumerator AddTail(Material mat)
    {
        Vector3 firstPos = Vector3.zero;
        Quaternion rot = Quaternion.identity;
        if(GameManager.Instance.tails.Count == 0)
        {
            firstPos = this.transform.position;
            rot = this.transform.rotation;
        }
        else
        {
            firstPos = GameManager.Instance.tails[GameManager.Instance.tails.Count - 1].transform.position;
            rot = GameManager.Instance.tails[GameManager.Instance.tails.Count - 1].transform.rotation;
        }
        Vector3 createPos = new Vector3(firstPos.x, 0.5f, firstPos.z);
        yield return new WaitForSeconds(0.2f);
        GameObject tail = Instantiate(tailPrefab, createPos, rot) as GameObject;
        tail.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;
        GameManager.Instance.tails.Add(tail);
        Debug.Log(GameManager.Instance.tails.Count);
    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Ground")
            canJump = true;
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Ground")
            canJump = false;
    }
}
