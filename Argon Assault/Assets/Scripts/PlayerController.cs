using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xSpeed, ySpeed;
    [SerializeField] float rangeX = 5f;
    [SerializeField] float rangeY = 4f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10;

    [SerializeField] float controlRollFactor = 10;
    [SerializeField] float positionRollFactor = 10;

    [SerializeField] float positionYawFactor = 5f;


    float xThrow, yThrow;


    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    void ProcessRotation()
    {


        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = transform.localPosition.x * positionRollFactor; //xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
        yThrow = Input.GetAxis("Vertical") * Time.deltaTime * ySpeed;

        float newXPos = transform.localPosition.x + xThrow;
        float newYPos = transform.localPosition.y + yThrow;

        float XPosClamp = Mathf.Clamp(newXPos, -rangeX, rangeX);
        float YPosClamp = Mathf.Clamp(newYPos, -rangeY, rangeY);

        transform.localPosition = new Vector3(XPosClamp, YPosClamp, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Fire");
        }
        else
        {
            Debug.Log("Not Firing");
        }
    }
}
