using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMovable {
    void Movable();
    void SSinit();
}

interface ILoading
{
    void Loading();
    bool LoadComp();
    void Loadinit();
}