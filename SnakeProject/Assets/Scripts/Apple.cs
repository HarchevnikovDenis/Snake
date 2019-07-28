using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = Random.Range(3f, 9f);
        StartCoroutine("LifeApple");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LifeApple()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("IsEat");
        Destroy(this.transform.parent.gameObject, 2f);
    }
}
