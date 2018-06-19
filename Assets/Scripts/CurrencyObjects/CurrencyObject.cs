using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CurrencyObject : ICurrency
{
    protected float _scale;

    public string Name { get; set; }

    public string Description { get; set; }
    public float FromUSDtoScale { get { return _scale; } set { _scale = value <= 0 ? _scale : value; } }

    public virtual float ConvertTo(float usdAmount)
    {
        return usdAmount * FromUSDtoScale;
    }
}
