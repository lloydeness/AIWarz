﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sensor : MonoBehaviour 
{
	public bool isColliding = false;
	public Collider ignoreThis;
	public List<Collider> targets;
	
	void Start()
	{
		targets = new List<Collider>();
	}
	
	void Update()
	{
		if(targets.Count ==0)
		{
			isColliding = false;	
		}
		else
		{
			for(int c = targets.Count-1; c >= 0; c--)
			{
				if( targets[c] == null)
				{
					targets.RemoveAt(c);
				}
			}
		}	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other != ignoreThis)
		{
			isColliding = true;
			targets.Add(other);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other != ignoreThis)
		{
			targets.Remove(other);
		}
	}
}
