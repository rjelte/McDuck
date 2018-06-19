using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public interface ICurrency
{
    string Name { get; set; }

    string Description { get; set; }

    float FromUSDtoScale { get;}

    float ConvertTo(float usdAmount);

}
