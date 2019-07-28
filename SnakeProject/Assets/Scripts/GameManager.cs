using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public Transform player;
    [SerializeField]
    private GameObject[] apples;
    public int score;
    public List<GameObject> tails;

    private void Awake() 
    {
        if(instance == null)
            instance = this;
        else
        {
            if(instance != this)
            {
                Destroy(this);
                return;
            }
        }
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> tails = new List<GameObject>();
        score = 0;
        InvokeRepeating("CreateApple", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void CreateApple()
    {
        Instantiate(apples[Random.Range(0, apples.Length)], new Vector3(player.position.x + Random.Range(-10f, 10f), 0.5f, player.position.z + Random.Range(-10f, 10f)), Quaternion.identity);
    }
}
