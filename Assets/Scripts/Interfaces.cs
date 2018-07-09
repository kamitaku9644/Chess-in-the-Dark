using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMovable {
    void MovableSS();
    bool Movable();
    void SSinit();
}

interface ILoading
{
    void Loading();
    bool LoadComp();
    void Loadinit();
}

interface ISelect
{
    void Select();
}

interface IMove
{
    void MoveRdy(GameObject hittedSquare);
    void Move();
    void Moveinit();
}

interface IDestroy
{
    void SetDestroyer();
}

public enum GameState
{
    start,
    initialize,
    selectrdy,
    select,
    moverdy,
    move,
    search,
    interval,
    result
}