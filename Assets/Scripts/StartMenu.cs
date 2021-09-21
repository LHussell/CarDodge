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

        settingsCarLeftHeadlight = settingsCar.transform.Find("LeftHeadlight").gameObject.GetComponent<Light>();
        settingsCarRightHeadlight = settingsCar.transform.Find("RightHeadlight").gameObject.GetComponent<Light>();
        settingsCarLeftLightBeam = settingsCar.transform.Find("LeftHeadlight").gameObject.GetComponent<VolumetricLightBeam>();
        settingsCarRightLightBeam = settingsCar.transform.Find("RightHeadlight").gameObject.GetComponent<VolumetricLightBeam>();

        exitCarLeftHeadlight = exitCar.transform.Find("LeftHeadlight").gameObject.GetComponent<Light>();
        exitCarRightHeadlight = exitCar.transform.Find("RightHeadlight").gameObject.GetComponent<Light>();
        exitCarLeftLightBeam = exitCar.transform.Find("LeftHeadlight").gameObject.GetComponent<VolumetricLightBeam>();
        exitCarRightLightBeam = exitCar.transform.Find("RightHeadlight").gameObject.GetComponent<VolumetricLightBeam>();


    }

    internal void TriggerMenuInstruction(string name)
    {
        switch (name)
        {
            case "CarMenuStart":
                gameRunning = true;
                gameObject.SetActive(false);
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
    }

    internal void ClearHighlight()
    {
        switch (lastCarHighlighted)
        {
            case CarType.START:
                startCarLeftHeadlight.enabled = false;
                startCarLeftLightBeam.enabled = false;
                startCarRightHeadlight.enabled = false;
                startCarRightLightBeam.enabled = false;
                break;
            case CarType.SETTINGS:
                settingsCarLeftHeadlight.enabled = false;
                settingsCarRightHeadlight.enabled = false;
                settingsCarLeftLightBeam.enabled = false;
                settingsCarRightLightBeam.enabled = false;
                break;
            case CarType.EXIT:
                exitCarLeftHeadlight.enabled = false;
                exitCarRightHeadlight.enabled = false;
                exitCarLeftLightBeam.enabled = false;
                exitCarRightLightBeam.enabled = false;
                break;
        }
    }

    private enum CarType
    {
        START,
        SETTINGS,
        EXIT
    }
}
