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
    void Moveinit();
}

public enum GameState { start,initialize, select, selectrdy, moverdy, move, search, interval, result }