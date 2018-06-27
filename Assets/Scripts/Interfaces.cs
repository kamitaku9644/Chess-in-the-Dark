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

interface IMove
{
    void MoveRdy(GameObject hittedSquare);
    void Move();
}

public enum GameState { start,initialize, select, moverdy, move, search, interval, result }