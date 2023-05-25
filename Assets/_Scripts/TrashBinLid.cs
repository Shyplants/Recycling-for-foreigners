using UnityEngine;

public class TrashBinLid : MonoBehaviour
{
    public bool isOpen;
    float xAngle;

    // Start is called before the first frame update
    void Start()
    {
        xAngle = 360f;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(xAngle < 0f) {
            xAngle += 360f;
        }

        if(isOpen) {
            xAngle -= Time.deltaTime * 90f;
            xAngle = Mathf.Max(xAngle, 270f);
        }
        else {
            xAngle += Time.deltaTime * 90f;
            xAngle = Mathf.Min(xAngle, 360f);
        }

        transform.rotation = Quaternion.Euler(xAngle, 0f, 0f);
    }
}
