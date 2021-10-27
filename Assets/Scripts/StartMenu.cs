using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLB;

public class StartMenu : MonoBehaviour
{
    public static StartMenu instance = null;

    GameObject startCar;
    GameObject settingsCar;
    GameObject exitCar;

    Rigidbody startCarTextRigidBody;
    Rigidbody settingsCarTextRigidBody;
    Rigidbody exitCarTextRigidBody;

    Light startCarLeftHeadlight;
    Light startCarRightHeadlight;
    Light settingsCarLeftHeadlight;
    Light settingsCarRightHeadlight;
    Light exitCarLeftHeadlight;
    Light exitCarRightHeadlight;

    VolumetricLightBeam startCarLeftLightBeam;
    VolumetricLightBeam startCarRightLightBeam;
    VolumetricLightBeam settingsCarLeftLightBeam;
    VolumetricLightBeam settingsCarRightLightBeam;
    VolumetricLightBeam exitCarLeftLightBeam;
    VolumetricLightBeam exitCarRightLightBeam;

    public bool gameRunning = false;
    public bool gameOver = false;
    public bool menuItemSelected = false;

    CarType lastCarHighlighted = CarType.START;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


        startCar = gameObject.transform.Find("CarMenuStart").gameObject;
        settingsCar = gameObject.transform.Find("CarMenuSettings").gameObject;
        exitCar = gameObject.transform.Find("CarMenuExit").gameObject;


        startCarLeftHeadlight = startCar.transform.Find("LeftHeadlight").gameObject.GetComponent<Light>();
        startCarRightHeadlight = startCar.transform.Find("RightHeadlight").gameObject.GetComponent<Light>();
        startCarLeftLightBeam = startCar.transform.Find("LeftHeadlight").gameObject.GetComponent<VolumetricLightBeam>();
        startCarRightLightBeam = startCar.transform.Find("RightHeadlight").gameObject.GetComponent<VolumetricLightBeam>();
        startCarTextRigidBody = startCar.transform.Find("StartText").gameObject.GetComponent<Rigidbody>();

        settingsCarLeftHeadlight = settingsCar.transform.Find("LeftHeadlight").gameObject.GetComponent<Light>();
        settingsCarRightHeadlight = settingsCar.transform.Find("RightHeadlight").gameObject.GetComponent<Light>();
        settingsCarLeftLightBeam = settingsCar.transform.Find("LeftHeadlight").gameObject.GetComponent<VolumetricLightBeam>();
        settingsCarRightLightBeam = settingsCar.transform.Find("RightHeadlight").gameObject.GetComponent<VolumetricLightBeam>();
        settingsCarTextRigidBody = settingsCar.transform.Find("SettingsText").gameObject.GetComponent<Rigidbody>();

        exitCarLeftHeadlight = exitCar.transform.Find("LeftHeadlight").gameObject.GetComponent<Light>();
        exitCarRightHeadlight = exitCar.transform.Find("RightHeadlight").gameObject.GetComponent<Light>();
        exitCarLeftLightBeam = exitCar.transform.Find("LeftHeadlight").gameObject.GetComponent<VolumetricLightBeam>();
        exitCarRightLightBeam = exitCar.transform.Find("RightHeadlight").gameObject.GetComponent<VolumetricLightBeam>();
        exitCarTextRigidBody = exitCar.transform.Find("ExitText").gameObject.GetComponent<Rigidbody>();


    }

    private void FixedUpdate()
    {
        if (menuItemSelected)
        {
            switch (lastCarHighlighted)
            {
                case CarType.START:
                    WiggleText(startCarTextRigidBody);
                    break;
                case CarType.SETTINGS:
                    WiggleText(settingsCarTextRigidBody);
                    break;
                case CarType.EXIT:
                    WiggleText(exitCarTextRigidBody);
                    break;
            }
        }
    }

    internal void TriggerMenuInstruction(string name)
    {
        switch (name)
        {
            case "CarMenuStart":
                gameRunning = true;
                gameObject.SetActive(false);
                break;
            case "CarMenuExit":
                Application.Quit();
                break;
        }
    }

    internal void HighlightMenuItem(string name)
    {
        switch (name)
        {
            case "CarMenuStart":
                startCarLeftHeadlight.enabled = true;
                startCarRightHeadlight.enabled = true;
                startCarLeftLightBeam.enabled = true;
                startCarRightLightBeam.enabled = true;
                lastCarHighlighted = CarType.START;
                break;
            case "CarMenuSettings":
                settingsCarLeftHeadlight.enabled = true;
                settingsCarRightHeadlight.enabled = true;
                settingsCarLeftLightBeam.enabled = true;
                settingsCarRightLightBeam.enabled = true;
                lastCarHighlighted = CarType.SETTINGS;
                break;
            case "CarMenuExit":
                exitCarLeftHeadlight.enabled = true;
                exitCarRightHeadlight.enabled = true;
                exitCarLeftLightBeam.enabled = true;
                exitCarRightLightBeam.enabled = true;
                lastCarHighlighted = CarType.EXIT;
                break;
        }
        menuItemSelected = true;
    }

    internal void ClearHighlight()
    {
        startCarLeftHeadlight.enabled = false;
        startCarLeftLightBeam.enabled = false;
        startCarRightHeadlight.enabled = false;
        startCarRightLightBeam.enabled = false;
        startCarTextRigidBody.rotation = Quaternion.identity;

        settingsCarLeftHeadlight.enabled = false;
        settingsCarRightHeadlight.enabled = false;
        settingsCarLeftLightBeam.enabled = false;
        settingsCarRightLightBeam.enabled = false;
        settingsCarTextRigidBody.rotation = Quaternion.identity;

        exitCarLeftHeadlight.enabled = false;
        exitCarRightHeadlight.enabled = false;
        exitCarLeftLightBeam.enabled = false;
        exitCarRightLightBeam.enabled = false;
        exitCarTextRigidBody.rotation = Quaternion.identity;

        menuItemSelected = false;
    }

    private enum CarType
    {
        START,
        SETTINGS,
        EXIT
    }

    bool rotateRight = true;
    private void WiggleText(Rigidbody textRigidBody)
    {
        Quaternion deltaRotation;

        if (rotateRight)
        {
            deltaRotation = Quaternion.Euler(new Vector3(0, 0, 70) * Time.fixedDeltaTime);
        } 
        else
        {
            deltaRotation = Quaternion.Euler(new Vector3(0, 0, -70) * Time.fixedDeltaTime);
        }
        textRigidBody.MoveRotation(textRigidBody.rotation * deltaRotation);

        if (textRigidBody.transform.eulerAngles.z < 350 && textRigidBody.transform.eulerAngles.z > 340) rotateRight = true;
        if (textRigidBody.transform.eulerAngles.z > 10 && textRigidBody.transform.eulerAngles.z < 20) rotateRight = false;
    }
}
