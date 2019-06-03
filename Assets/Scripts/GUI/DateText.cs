using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SolarSystem.Model;

namespace SolarSystem.GUI
{
    //show date info
    public class DateText : MonoBehaviour
    {
        private Text showingText = null;
        private string dateText = "Date\n";
        private string slash = "/";
        private string space = " ";
        private string spot = ":";
        private string zero = "0";

        // Use this for initialization
        private void Start()
        {
            showingText = GetComponent<Text>();
        }

        // Update is called once per frame
        private void Update()
        {
            var date = SolarMathModel.Date();
            var str = new System.Text.StringBuilder();

            //up date
            str.Append(dateText);

            //add hour
            if (date.Hour.ToString().Length == 1)
                str.Append(zero);

            str.Append(date.Hour);
            str.Append(spot);

            //add minute
            if (date.Minute.ToString().Length == 1)
                str.Append(zero);

            str.Append(date.Minute);

            //space
            str.Append(space);

            //add day
            if (date.Day.ToString().Length == 1)
                str.Append(zero);

            str.Append(date.Day);
            str.Append(slash);

            //ad month
            if (date.Month.ToString().Length == 1)
                str.Append(zero);

            str.Append(date.Month);
            str.Append(slash);

            //add year
            str.Append(date.Year);

            //to text
            showingText.text = str.ToString();
        }
    }
}
