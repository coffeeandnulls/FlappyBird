using UnityEngine;

public class pipeScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed*Time.deltaTime);

        if(transform.position.x<-75f)
        {
            Destroy(gameObject);
        }
    }
}
