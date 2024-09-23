using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xSpeed, ySpeed;
    [SerializeField] float rangeX = 5f;
    [SerializeField] float rangeY = 4f;
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
   
        float xThrow = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
        float yThrow = Input.GetAxis("Vertical") * Time.deltaTime * ySpeed;

        float newXPos = transform.localPosition.x + xThrow;
        float newYPos = transform.localPosition.y + yThrow;

        float XPosClamp = Mathf.Clamp(newXPos, -rangeX, rangeX);
        float YPosClamp = Mathf.Clamp(newYPos, -rangeY, rangeY);

        transform.localPosition = new Vector3 (XPosClamp, YPosClamp, transform.localPosition.z);
        
    }
}
