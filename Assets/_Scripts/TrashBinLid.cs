using UnityEngine;

public class TrashBinLid : MonoBehaviour
{
    public bool isOpen;
    float xAngle, yAngle;
    bool bInit = false;

    // Start is called before the first frame update
    public void Init(float _yAngle)
    {
        bInit = true;
        xAngle = 360f;
        yAngle = _yAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if(!bInit) return;

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

        transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
    }
}
