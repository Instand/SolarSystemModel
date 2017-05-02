using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SolarSystem.Objects3D;

namespace SolarSystem.Controller
{
    //casts raycast in the space
    public class Raycaster : MonoBehaviour
    {
        private Camera solarView = null;
        private RaycastHit hit;
        private Ray ray;

        //before first frame
        private void Start()
        {
            solarView = Camera.main;
        }

        // Update is called once per frame
        private void Update()
        {
            //check mouse press
            if (Input.GetMouseButtonDown(0))
            {
                ray = solarView.ScreenPointToRay(Input.mousePosition);

                //cast a ray
                if (Physics.Raycast(ray, out hit))
                {
                    var object3D = hit.transform.GetComponent<Object3D>();

                    //TODO interact with 3d objects
                    if (object3D)
                        Debug.Log(object3D.name);
                }
            }
        }
    }
}
