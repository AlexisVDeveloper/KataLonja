using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITableView
{
    void SubscribeToButtonEvent(Action callback);
}
