using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("How fast ship moves right and left")] [SerializeField] float xSpeed;
    [Tooltip("How fast ship moves up and down")] [SerializeField] float ySpeed;
    [Tooltip("How far player moves horizontally")] [SerializeField] float rangeX = 5f;
    [Tooltip("How far player moves vertically")] [SerializeField] float rangeY = 4f;

    [Header("Rotation Settings based Input")]
    [SerializeField] float controlPitchFactor = -10;
    [SerializeField] float controlRollFactor = 10;

    [Header("Rotation Settings based position")]
    [SerializeField] float positionRollFactor = 10;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Laser gun array")]
    [SerializeField] GameObject[] lasers;


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
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool trueOrFalse)
    {
        foreach (var laser in lasers)
        {
            laser.GetComponent<ParticleSystem>().enableEmission = trueOrFalse;
        }
    }

    
}
