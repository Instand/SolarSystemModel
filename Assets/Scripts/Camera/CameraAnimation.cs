using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Model;
using SolarSystem.Core;
using SolarSystem.Interfaces;

namespace SolarSystem.Controller
{
    /// <summary>
    /// Animates camera
    /// </summary>
    public class CameraAnimation : MonoBehaviour
    {
        private bool animated = false;
        private Vector3 target;

        [SerializeField]
        private float cameraSpeed = 2.0f;
        private float distance = 0;

        private IVisualSolarObject solarObject = null;
        private float currentCameraSpeed = 0;
        private float currentCameraRotation = 0;

        [SerializeField]
        private float acceleration = 0.05f;

        [SerializeField]
        private float rotationSpeed = 0.5f;

        [SerializeField]
        private float rotationAcceleration = 0.1f;

        [SerializeField]
        private float rotateAngle = 5.0f;

        [SerializeField]
        private float activateModelDelta = 1.0f;

        // init
        private void Start()
        {
            currentCameraSpeed = cameraSpeed;
            currentCameraRotation = rotationSpeed;
        }

        //active helper
        private IEnumerator ActivateModel()
        {
            yield return new WaitForSeconds(activateModelDelta);
        }

        // after frame
        private void LateUpdate()
        {
            if (animated)
            {
                var onTarget = solarObject.GetTransform().position - transform.position;

                //rotation
                transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, onTarget, rotationSpeed * Time.deltaTime, 10.0f));
                currentCameraRotation += rotationAcceleration;

                //angle
                var angle = Vector3.Angle(onTarget, transform.forward);

                //translation
                var pos = Vector3.Lerp(transform.position, target, Time.deltaTime * currentCameraSpeed);
                transform.position = pos;
                currentCameraSpeed += acceleration;

                if ((Vector3.Distance(transform.position, target) <= distance) && (angle < rotateAngle))
                {
                    animated = false;

                    SolarMathModel.CameraController.Active = true;
                    //SolarMathModel.CameraController.updateCamera();
                    SolarMathModel.ResumeModel();
                }
            }
        }

        /// <summary>
        /// Animates camera on obj
        /// </summary>
        /// <param name="obj"></param>
        public void LookAt(Objects obj)
        {
            solarObject = SolarMathModel.Container3D().GetObject(obj);

            if (solarObject != null)
            {
                //calculation
                target = SolarMathModel.ViewPositionOfObject(obj);
                distance = Vector3.Distance(solarObject.GetTransform().position, target);
                SolarMathModel.StopModel();

                animated = true;
                currentCameraSpeed = cameraSpeed;
                currentCameraRotation = rotationSpeed;

                //setup camera controller
                SolarMathModel.CameraController.Active = false;
                SolarMathModel.CameraController.Target = solarObject;
            }
        }
    }
}
