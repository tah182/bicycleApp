using System;

namespace CycloBit.Common.Objects {
    public class LatLng {
        private double lat, lng;

        ///<summary>
        /// Used for EF creation of object
        ///</summary>
        public LatLng() { }

        public LatLng(double lat, double lng) {
            this.Lat = lat;
            this.Lng = lng;
        }

        public LatLng(string latLng) {
            string[] latLngSplit = latLng.Split(',');

            if (latLngSplit.Length != 2)
                throw new ArgumentException($"Lat/Lng string provided in incorrect format. Expected: lat,lng Received: {latLng}");

            double _lat, _lng;

            if (!double.TryParse(latLngSplit[0], out _lat))
                throw new ArgumentException($"Lat/Lng string provided in incorrect format. Expected: lat,lng Received: {latLng}");

            if (!double.TryParse(latLngSplit[1], out _lng))
                throw new ArgumentException($"Lat/Lng string provided in incorrect format. Expected: lat,lng Received: {latLng}");

            this.Lat = _lat;
            this.Lng = _lng;
        }

        public double Lat { 
            get { return this.lat; }
            set {
                if (value < -90 || value > 90)
                    throw new ArgumentException("Latitude value must be between -90 and 90 degrees.");

                this.lat = Math.Round(value, 5);
            }
        }
        public double Lng { 
            get { return this.lng; }
            set {
                if (value < -90 || value > 90)
                    throw new ArgumentException("Longitude value must be between -180 and 180 degrees.");

                this.lng = Math.Round(value, 5);
            }
        }

        ///<summary>
        /// Returns distance in meters
        ///</summary>
        public double DistanceFrom(LatLng compareTo) {
            double theta = this.Lng - compareTo.Lng;
            double dist = Math.Sin(deg2rad(this.Lat)) * Math.Sin(deg2rad(compareTo.Lat)) + Math.Cos(deg2rad(this.Lat)) * Math.Cos(deg2rad(compareTo.Lat)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = dist * 60 * 1.1515;
            
            return dist;
        }

        public bool IsDistanceFromWithin(LatLng compareTo, long meters, bool exclusive = false) {
            if (exclusive)
                return this.DistanceFrom(compareTo) < meters;

            return this.DistanceFrom(compareTo) <= meters;
        }

        public override string ToString() {
            return this.Lat.ToString("0.00000") + "," + this.Lng.ToString("0.00000");
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg) {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad) {
            return (rad / Math.PI * 180.0);
        }

    }
}