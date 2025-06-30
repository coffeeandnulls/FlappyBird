using UnityEngine;

public class spawnManagerScript : MonoBehaviour
{
    public GameObject pipes;
    private float timer = 0;
    private float spawnRate = 2f;
    [SerializeField]
    private float minY, maxY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pipeSpawn();
    }

    void pipeSpawn()
    {
        if(timer<spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float spawnY=Random.Range(minY, maxY);
            Instantiate(pipes, (new Vector3(transform.position.x,spawnY,0)), transform.rotation);
            timer = 0;
        }
    }
}
