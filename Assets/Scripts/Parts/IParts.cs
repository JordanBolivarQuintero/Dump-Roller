using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParts 
{
    void Grab();
    void Carry();
    void Place();
    void TurnOff();
    Texture GetTexture();
}
