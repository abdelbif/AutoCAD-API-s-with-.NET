using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;


namespace DotNet_Autocad
{
    public static class CommonUtil
    {
        //method to get all the verices of polylines and return 
        //it to the calling method in comma separated value
        public static string GetPolylineCoordinates(Polyline polyline)
        {
            var vCount = polyline.NumberOfVertices;
            Point2d coord;
            string coords = "";
            for(int i = 0; i<=vCount - 1; i++ )
            {
                coord = polyline.GetPoint2dAt(i);
                coords += coord[0].ToString() + "," + coord[1].ToString();
                if (i < vCount - 1) 
                    coords += ",";
            }
            return coords;
        }
    }
}
