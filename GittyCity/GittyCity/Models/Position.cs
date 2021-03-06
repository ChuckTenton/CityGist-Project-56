﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace GittyCity.Models
{
    public interface IRijksdriehoekComponent
    {
        string ConvertToLatLong(double x, double y);
    }
    // Deze hele calss is ervoor om de Rdx en Rdy om te zetten naar de coördinaten die nodig zijn.

    public class Position : IRijksdriehoekComponent
    {
        public string ConvertToLatLong(double x, double y)
        {
            string result = null;

            // The city "Amsterfoort" is used as reference "Rijksdriehoek" coordinate.
            int referenceRdX = 155000;
            int referenceRdY = 463000;

            double dX = (double)(x - referenceRdX) * (double)(Math.Pow(10, -5));
            double dY = (double)(y - referenceRdY) * (double)(Math.Pow(10, -5));

            double sumN =
                (3235.65389 * dY) +
                (-32.58297 * Math.Pow(dX, 2)) +
                (-0.2475 * Math.Pow(dY, 2)) +
                (-0.84978 * Math.Pow(dX, 2) * dY) +
                (-0.0655 * Math.Pow(dY, 3)) +
                (-0.01709 * Math.Pow(dX, 2) * Math.Pow(dY, 2)) +
                (-0.00738 * dX) +
                (0.0053 * Math.Pow(dX, 4)) +
                (-0.00039 * Math.Pow(dX, 2) * Math.Pow(dY, 3)) +
                (0.00033 * Math.Pow(dX, 4) * dY) +
                (-0.00012 * dX * dY);
            double sumE =
                (5260.52916 * dX) +
                (105.94684 * dX * dY) +
                (2.45656 * dX * Math.Pow(dY, 2)) +
                (-0.81885 * Math.Pow(dX, 3)) +
                (0.05594 * dX * Math.Pow(dY, 3)) +
                (-0.05607 * Math.Pow(dX, 3) * dY) +
                (0.01199 * dY) +
                (-0.00256 * Math.Pow(dX, 3) * Math.Pow(dY, 2)) +
                (0.00128 * dX * Math.Pow(dY, 4)) +
                (0.00022 * Math.Pow(dY, 2)) +
                (-0.00022 * Math.Pow(dX, 2)) +
                (0.00026 * Math.Pow(dX, 5));

            double referenceWgs84X = 52.15517;
            double referenceWgs84Y = 5.387206;

            double latitude = referenceWgs84X + (sumN / 3600);
            double longitude = referenceWgs84Y + (sumE / 3600);

            result = string.Format("{0}, {1}",
                latitude.ToString(CultureInfo.InvariantCulture.NumberFormat),
                longitude.ToString(CultureInfo.InvariantCulture.NumberFormat));

            return result;
        }
    }
}