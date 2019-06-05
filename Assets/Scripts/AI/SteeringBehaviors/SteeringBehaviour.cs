﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public abstract class SteeringBehaviour : ScriptableObject
{
    [Slider(0f, 01f)] public float weightung = 1f;
    public abstract Vector3 GetForce(AI owner);


    public virtual void OnDrawGizmosSelected(AI owner) { }





}