using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarSystem.Controller
{
    //camera controller
    public class OrbitController : MonoBehaviour
    {
        //The target of the camera. The camera will always point to this object.
        private Transform target;

        //The default distance of the camera from the target.
        [SerializeField]
        private float distanceValue = Core.Values.solarDistance;

        //Control the speed of zooming and dezooming.
        [SerializeField]
        private float zoomValue = 35000.0f;

        //The position of the cursor on the screen. Used to rotate the camera.
        private float x = 0.0f;
        private float y = 0.0f;

        //Distance vector. 
        private Vector3 distance;

        //default values
        private float defaultZoomLimitValue = 200000.0f;
        private float defaultZoomSpeedValue = 35000.0f;
        private float zoomLimitValue = 0;
        private float zoomOutLimitValue = 0;
        //private 

        [SerializeField]
        private float lookSpeedValue = 10.0f;

        //hash
        private string mouseX = "Mouse X";
        private string mouseY = "Mouse Y";
        private string mouseWheel = "Mouse ScrollWheel";

        //target to orbit from
        public void setTarget(Transform target)
        {
            this.target = target;
        }

        //set zoom value
        public void setZoomValue(float value)
        {
            zoomValue = value;
        }
        
        //before first frame
        private void Start()
        {
            distance = new Vector3(0.0f, 0.0f, -distanceValue);

            zoomLimitValue = defaultZoomLimitValue;
            zoomOutLimitValue = zoomLimitValue;
            zoomValue = defaultZoomSpeedValue;

            Vector2 angles = transform.localEulerAngles;
            x = angles.x;
            y = angles.y;

            rotate(x, y);
        }

        //after every frame
        private void LateUpdate()
        {
            if (target)
            {
                rotateControls();
                zoom();
            }
        }

        /**
         * Rotate the camera when the first button of the mouse is pressed.
         * 
         */
        private void rotateControls()
        {
            //right button
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis(mouseX) * lookSpeedValue;
                y += Input.GetAxis(mouseY) * lookSpeedValue;

                rotate(x, y);
            }
        }

        /**
         * Transform the cursor mouvement in rotation and in a new position
         * for the camera.
         */
        private void rotate(float x, float y)
        {
            //Transform angle in degree in quaternion form used by Unity for rotation.
            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);

            //The new position is the target position + the distance vector of the camera
            //rotated at the specified angle.
            Vector3 position = rotation * distance + target.position;

            //Update the rotation and position of the camera.
            transform.rotation = rotation;
            transform.position = position;
        }

        /**
         * Zoom or dezoom depending on the input of the mouse wheel.
         */
        private void zoom()
        {
            if (Input.GetAxis(mouseWheel) < 0.0f)
            {
                zoomOut();
            }
            else if (Input.GetAxis(mouseWheel) > 0.0f)
            {
                zoomIn();
            }
        }

        /**
         * Reduce the distance from the camera to the target and
         * update the position of the camera (with the Rotate function).
         */
        private void zoomIn()
        {
            distanceValue -= zoomValue;
            distance = new Vector3(0.0f, 0.0f, -distanceValue);
            rotate(x, y);
        }

        /**
         * Increase the distance from the camera to the target and
         * update the position of the camera (with the Rotate function).
         */
        private void zoomOut()
        {
            distanceValue += zoomValue;
            distance = new Vector3(0.0f, 0.0f, -distanceValue);
            rotate(x, y);
        }
    }
}
