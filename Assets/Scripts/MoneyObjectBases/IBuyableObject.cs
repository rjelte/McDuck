using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuyableObject
{

    string Name { get; set; }

    string Description { get; set; }

    float Price { get; set; }

    float ConvertToObjectCount(float usdAmount);
}
