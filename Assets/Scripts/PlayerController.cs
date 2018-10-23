using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 7f;
    [SerializeField] GameObject gun;
    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    void FreezeControlsOnImpact() // called by string reference in CollisionHandler.cs
    {
        isControlEnabled = false;
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffsetThisFrame = xThrow * controlSpeed * Time.deltaTime;
        float yOffsetThisFrame = yThrow * controlSpeed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffsetThisFrame;
        float rawNewYPos = transform.localPosition.y + yOffsetThisFrame;

        rawNewXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        rawNewYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange - 1);

        transform.localPosition = new Vector3(rawNewXPos, rawNewYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;


        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire")){
            gun.SetActive(true);
        }
        else
        {
            gun.SetActive(false);
        }
    }
}
