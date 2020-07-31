using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFormat {
     public static   float FloatFormat(float oldData)
    {
        float y = float.Parse(oldData.ToString("#0.00"));
        return y;
    }


    string str = 6.500000.ToString("f2");//6.50

    double bbb = System.Math.Round(1.2201201, 2);

}
