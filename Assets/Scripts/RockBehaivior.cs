using UnityEngine;

public class RockBehaivior : MonoBehaviour
{

    public float yRotation;
    public float xRotation;
    public float zRotation;
    public float rotationSpeed = 0.2f;
    public int movementType = 0;
    public GameObject rock;

    // Update is called once per frame
    void Update()
    {
        if (movementType == 0)
        {
            yRotation += rotationSpeed;
            transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
            
        }
       
        if (movementType == 1)
        {
            xRotation += rotationSpeed;
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            rock.transform.localRotation = Quaternion.Euler(-xRotation, 0f, 0f);
        }

        if (movementType == 2)
        {
            zRotation += rotationSpeed;
            transform.localRotation = Quaternion.Euler(0f, 0f, zRotation);
            rock.transform.localRotation = Quaternion.Euler(0f, 0f, -zRotation);
        }
    }
}
