using System.Linq;
using UnityEngine;
using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class VisHistogram : Vis
{
    public VisHistogram()
    {
        title = "Histogram";

        //Define Data Mark and Tick Prefab
        dataMarkPrefab = (GameObject)Resources.Load("Prefabs/DataVisPrefabs/Marks/Cube");
        tickMarkPrefab = (GameObject)Resources.Load("Prefabs/DataVisPrefabs/VisContainer/Tick");
    }

    public override GameObject CreateVis(GameObject container)
    {

        var asd = dataSets[0].ElementAt(0);
        setBin();

        base.CreateVis(container);

        //## 01:  Create Axes and Grids


        double[] xAxis = dataSets[0].ElementAt(0).Value;
        double[] yAxis = new double[100];//dataSets[0].ElementAt(1).Value;


        // X Axis
        visContainer.CreateAxis(dataSets[0].ElementAt(0).Key, xAxis, Direction.X);
        visContainer.CreateGrid(Direction.X, Direction.Y);

        // Y Axis
        visContainer.CreateAxis(dataSets[0].ElementAt(1).Key, yAxis, Direction.Y);

        //## 02: Set Remaining Vis Channels (Color,...)
        visContainer.SetChannel(VisChannel.XPos, dataSets[0].ElementAt(0).Value);
        visContainer.SetChannel(VisChannel.YPos, dataSets[0].ElementAt(1).Value);
        visContainer.SetChannel(VisChannel.Color, dataSets[0].ElementAt(3).Value);

        //## 03: Draw all Data Points with the provided Channels 
        visContainer.CreateDataMarks(dataMarkPrefab);

        //## 04: Rescale Chart
        visContainerObject.transform.localScale = new Vector3(width, height, depth);

        return visContainerObject;
    }

    public void setBin()
    {
        double[] a = dataSets[0].ElementAt(0).Value;
        int len = a.Length;
        xyzTicks[0] = (int)Math.Ceiling(Math.Sqrt(len));
    }


}
