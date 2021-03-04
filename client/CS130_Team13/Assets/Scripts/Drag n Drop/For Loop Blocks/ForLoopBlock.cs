﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForLoopBlock : PanelItem, ISubPanel
{
    [SerializeField]
    private GameObject myPanel = null;

    /// <summary>
    /// simulate a guard probe event if dragged item is not for loop
    /// </summary>
    public void IsOccupied() {
        if (DragDropManager.instance.currentlyDraggedItem.GetComponent<ForLoopBlock>())
            return;
        else
            myPanel.GetComponent<CodingPanel>().ReportGuardProbe();
    }

    public void ItemCame(GameObject newItem) {
        if (DragDropManager.instance.currentlyDraggedItem.GetComponent<ForLoopBlock>())
            return;
        else
            myPanel.GetComponent<CodingPanel>().PutItem(newItem);
    }

    public override string GetInformation() {
        string result = "";
        // TODO: add for loop headings

        // get information from children blocks
        result += myPanel.GetComponent<CodingPanel>().GetInformation();

        return result;
    }

    public override int GetCost() {
        int result = 0;

        // TODO: add cost overheads

        result += myPanel.GetComponent<CodingPanel>().GetCost();

        return result;
    }
}