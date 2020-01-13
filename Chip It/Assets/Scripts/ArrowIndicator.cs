﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    private PlayerInteraction interaction;
    private Vector2 resetPosition;

    private Vector2 start;
    private Vector2 end;
    private bool mouseDown = false;

    /// <summary>
    /// Runs when instance starts
    /// </summary>
    private void Start() {
        this.resetPosition = GetComponent<Transform>().position;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<Transform>().position = PlayerInteraction.interaction.lastPosition;
            this.start = Input.mousePosition;
            this.start = Camera.main.ScreenToWorldPoint(this.start); // Converts mouse positioning from screen to world
            this.mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            GetComponent<Transform>().position = this.resetPosition;
            this.mouseDown = false;
        }
        this.end = Input.mousePosition;
        this.end = Camera.main.ScreenToWorldPoint(this.end); // Converts mouse positioning from screen to world

        if (mouseDown == true && this.start != this.end) {
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 0, Convert.ToSingle(Math.Atan((this.start.y - this.end.y) / (this.start.x - this.end.x)) * 180 / Math.PI) - 45);

            GetComponent<Transform>().rotation = rot;
        }
    }
}