using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public float speed;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.tails.Count == 1)
        {
            target = GameManager.Instance.player;
        }
        else
        {
            target = GameManager.Instance.tails[GameManager.Instance.tails.Count - 2].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
        if(Vector3.Distance(target.position, this.gameObject.transform.position) < 1.0f)
            return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
