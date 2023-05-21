using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    Rigidbody rBody;
    
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        Vector3 pos = rBody.position;
        
        rBody.position -= transform.forward * speed * Time.fixedDeltaTime;
        rBody.MovePosition(pos);
    }
}
