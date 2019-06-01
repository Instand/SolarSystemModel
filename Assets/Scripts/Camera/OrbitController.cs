using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using SolarSystem.Interfaces;

namespace SolarSystem.Controller
{
    /// <summary>
    /// Camera controller
    /// </summary>
    public sealed class OrbitController : MonoBehaviour
    {
        /// <summary>
        /// The target of the camera. The camera will always point to this object.
        /// </summary>
        private IVisualSolarObject target;

        /// <summary>
        /// The default distance of the camera from the target.
        /// </summary>
        [SerializeField]
        private float distanceValue = Core.Values.solarDistance;

        /// <summary>
        /// Control the speed of zooming and dezooming.
        /// </summary>
        [SerializeField]
        private float zoomValue = 35000.0f;

        /// <summary>
        /// Min zoom value
        /// </summary>
        [SerializeField]
        private float minZoomValue = 70000.0f;

        /// <summary>
        /// Max zoom value
        /// </summary>
        [SerializeField]
        private float maxZoomValue = Core.Values.solarDistance;

        //The position of the cursor on the screen. Used to rotate the camera.
        private float x = 0.0f;
        private float y = 0.0f;
        private float xTemp = 0;
        private float yTemp = 0;

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

        [SerializeField]
        private bool isMobile = false;

        [SerializeField]
        private float sensivity = 0.4f;
        private Vector3 startPoint;
        private Vector3 nextPoint;
        private Camera mainCamera;

        /// <summary>
        /// Controller state
        /// </summary>
        private bool active = true;

        /// <summary>
        /// Main target object
        /// </summary>
        public IVisualSolarObject Target
        {
            set
            {
                target = value;
            }
            get
            {
                return target;
            }
        }

        /// <summary>
        /// Distance property
        /// </summary>
        public Vector3 Distance
        {
            set
            {
                distance = value;
            }
            get
            {
                return distance;
            }
        }

        /// <summary>
        /// Default zoom limit
        /// </summary>
        public float DefaultZoomLimit
        {
            get
            {
                return defaultZoomLimitValue;
            }
        }

        /// <summary>
        /// Main camera reference
        /// </summary>
        public Camera Camera
        {
            get
            {
                return mainCamera;
            }
        }

        /// <summary>
        /// Activation
        /// </summary>
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        //set zoom value
        public void setZoomValue(float value)
        {
            zoomValue = value;
        }

        /// <summary>
        /// Updates x and y
        /// </summary>
        public void updateCamera()
        {
            transform.LookAt(target.getTransform());

            distanceValue = (target.getTransform().position - transform.position).magnitude;
            distance = new Vector3(0.0f, 0.0f, -distanceValue);

            Vector2 angles = transform.localEulerAngles;
            x = angles.x;
            y = angles.y;

            rotate(x, y);
        }
        
        //before first frame
        private void Start()
        {
            distance = new Vector3(0.0f, 0.0f, -distanceValue);

            mainCamera = GetComponent<Camera>();

            zoomLimitValue = defaultZoomLimitValue;
            zoomOutLimitValue = zoomLimitValue;
            zoomValue = defaultZoomSpeedValue;

            Vector2 angles = transform.localEulerAngles;
            x = angles.x;
            y = angles.y;

            rotate(x, y);
        }

        /// <summary>
        /// After every frame
        /// </summary>
        private void LateUpdate()
        {
            if (active)
            {
                if (target != null)
                {
                    //distanceValue = (target.getTransform().position - transform.position).magnitude;
                    //distance = new Vector3(0.0f, 0.0f, -distanceValue);
                    //rotate(x, y);

                    rotateControls();
                    zoom();
                }
            }
        }

        /**
         * Rotate the camera when the first button of the mouse is pressed.
         * 
         */
        private void rotateControls()
        {
            if (!isMobile)
            {
                if (Input.GetMouseButton(1))
                {
                    x += Input.GetAxis(mouseX) * lookSpeedValue;
                    y += Input.GetAxis(mouseY) * lookSpeedValue;

                    rotate(x, y);
                }
            }
            else
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (Input.touchCount > 0)
                    {
                        if (Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                            startPoint = Input.GetTouch(0).position;
                            xTemp = x;
                            yTemp = y;
                        }

                        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
                        {
                            nextPoint = Input.GetTouch(0).position;

                            x = xTemp + (nextPoint.x - startPoint.x) * 180.0f / Screen.width;
                            y = yTemp - (nextPoint.y - startPoint.y) * 90.0f / Screen.height;

                            rotate(x, y);
                        }
                        else if (Input.touchCount == 2)
                        {
                            float pinchAmount = 0;
                            Quaternion desiredRotation = transform.rotation;

                            DetectTouch.Calculate();

                            if (Mathf.Abs(DetectTouch.pinchDistanceDelta) > 0)
                            {
                                pinchAmount = DetectTouch.pinchDistanceDelta;

                                if (DetectTouch.pinchDistanceDelta >= 0)
                                {
                                    if (Vector3.Distance(transform.position, target.getTransform().position) > minZoomValue)
                                        distanceValue -= pinchAmount * sensivity;
                                }
                                else
                                {
                                    if (Vector3.Distance(transform.position, target.getTransform().position) < maxZoomValue)
                                        distanceValue += Mathf.Abs(pinchAmount) * sensivity;
                                }

                                distance = new Vector3(0.0f, 0.0f, -distanceValue);
                            }

                            transform.position += transform.forward * pinchAmount * sensivity;
                        }
                    }
                }
            }
        }

        /**
         * Transform the cursor mouvement in rotation and in a new position
         * for the camera.
         */
        private void rotate(float x, float y)
        {
            //Transform angle in degree in quaternion form used by Unity for rotation.
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            //The new position is the target position + the distance vector of the camera
            //rotated at the specified angle.
            Vector3 position = rotation * distance + target.getTransform().position;

            //Update the rotation and position of the camera.
            transform.rotation = rotation;
            transform.position = position;
        }

        /**
         * Zoom or dezoom depending on the input of the mouse wheel.
         */
        private void zoom()
        {
            if (!isMobile)
            {
                if (Input.GetAxis(mouseWheel) < 0.0f)
                    zoomOut();
                else if (Input.GetAxis(mouseWheel) > 0.0f)
                    zoomIn();
            }
        }

        /**
         * Reduce the distance from the camera to the target and
         * update the position of the camera (with the Rotate function).
         */
        private void zoomIn()
        {
            if ((distanceValue - zoomValue) > minZoomValue)
            {
                distanceValue -= zoomValue;
                distance = new Vector3(0.0f, 0.0f, -distanceValue);
                rotate(x, y);
            }
        }

        /**
         * Increase the distance from the camera to the target and
         * update the position of the camera (with the Rotate function).
         */
        private void zoomOut()
        {
            if ((distanceValue + zoomValue) < maxZoomValue)
            {
                distanceValue += zoomValue;
                distance = new Vector3(0.0f, 0.0f, -distanceValue);
                rotate(x, y);
            }
        }
    }
}
