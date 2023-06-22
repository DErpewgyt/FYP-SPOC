using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Measurements : MonoBehaviour
{
   public GameObject patientMeasurement;
   public GameObject miniRuler;

   void Update()
   {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject != patientMeasurement)
                {
                    patientMeasurement.SetActive(false);
                    miniRuler.SetActive(true);
                }
            }
            else
            {
                patientMeasurement.SetActive(false);
                miniRuler.SetActive(true);
            }
        }
   }

   public void onMeasurementClick()
   {
        patientMeasurement.SetActive(true);
        miniRuler.SetActive(false);
   }
}
