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
        gameObject.GetComponent<Animator>().SetTrigger("IsEat");
        Destroy(this.transform.parent.gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")                                 //Змейка съела яблоко
        {
            gameObject.GetComponent<Animator>().SetTrigger("IsEat");
            Destroy(gameObject.transform.parent.gameObject, 2f);
            GameManager.Instance.score += 1;
            Debug.Log(GameManager.Instance.score);
        }
    }
}
