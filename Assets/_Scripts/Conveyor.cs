using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    Rigidbody rBody;
    
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        speed = 2;
    }

    void FixedUpdate() 
    {
        Vector3 pos = rBody.position;
        
        rBody.position -= transform.right * speed * Time.fixedDeltaTime;
        rBody.MovePosition(pos);
    }
}
