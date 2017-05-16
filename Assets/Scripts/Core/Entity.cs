using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Objects3D;
using SolarSystem.Model;

namespace SolarSystem.Core
{
    //base entity of solar system
    public class Entity : MonoBehaviour
    {
        private Camera solarView = null;
        private Objects currentObject = Objects.SolarSystemView;
        private Controller.OrbitController cameraController = null;
        private Light sunLight = null;

        [SerializeField]
        private float distanceModifier = 1000.0f;

        [SerializeField]
        private float lightIntensity = 1.6f;

        //on create
        private void Awake()
        {
            //create light
            var sun = SolarMathModel.container3D().getObject(Objects.Sun);
            sunLight = (sun as MonoBehaviour).gameObject.AddComponent<Light>();

            if (sunLight)
            {
                sunLight.type = LightType.Point;
                sunLight.range = Values.solarDistance * distanceModifier;
                sunLight.intensity = lightIntensity;
            }
            else
                Debug.Log("No light object at scene");

            //view
            solarView = Camera.main;
            solarView.transform.position = new Vector3(Values.solarDistance, Values.solarDistance, Values.solarDistance);
            solarView.transform.LookAt(Vector3.zero);
            solarView.farClipPlane = CameraSettings.farPlane;
            solarView.nearClipPlane = CameraSettings.nearPlane * 0.0001f;

            //default values
            SolarMathModel.setSolarSystemSpeed(Values.startSpeed);
            SolarMathModel.changeSolarSystemScale(Values.startSize);

            //controller
            cameraController = solarView.GetComponent<Controller.OrbitController>();
            cameraController.setTarget(SolarMathModel.container3D().getObject(Objects.Sun).getTransform());
        }

        //every frame
        private void Update()
        {
            //set delta
            SolarMathModel.setDeltaTime(Time.deltaTime);

            //calculate time
            SolarMathModel.advanceTime(currentObject);

            var count = (int)Objects.EarthCloud;

            for (int i = 0; i < count; ++i)
                SolarMathModel.calculateObjectPosition((Objects)i);
        }
    }
}
