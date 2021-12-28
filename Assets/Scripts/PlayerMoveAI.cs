using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class PlayerMoveAI : MoveBase
{
    private Vector3 targetPosition;
    public Vector3 defaultPosition;
    public Vector3 innerTSorRPosition;
    public Vector3 outerTSorRPosition;
    public Vector3 _SVRPostion;
    public Vector3 tsEcPosition1;
    public Vector3 tsEcPosition2;
    public Vector3 tsEcPosition3;
    public Vector3 tsEcPosition4;
    public Vector3 tsReadyPositionDown;
    public Vector3 tsReadyPositionRight;
    public Vector3 tsSafePosition;
    public Vector3 hcRangerPositionLeft;
    public Vector3 hcRangerPositionRight;
    public List<Vector3> chargePositionList;
    public Vector3 _2ndTsReadyPosition;
    public Vector3 _2ndDSorRInnerLeft;
    public Vector3 _2ndDSorRInnerRight;
    public Vector3 _2ndDSorROuterLeft;
    public Vector3 _2ndDSorROuterRight;
    public Vector3 rdyForLanceUpRight;
    public Vector3 rdyForLanceLeftDown;
    public List<Vector3> llStartPosition;
    private int startPosIndex;
    public List<Vector3> llFinishPosition;
    public Toggle autoToggle;
    private int movecount;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private PlayerList playerList;
    public int priority;
    public PriorityMessenger priorityMessenger;
    public BossAI boss;
    public bool isMelee;
    public bool isTank;
    protected override void Start()
    {
        base.Start();
        chargePositionList = new List<Vector3>(8);
        llStartPosition = new List<Vector3>(4);
        llFinishPosition = new List<Vector3>(8);
        chargePositionList.Insert(0, new Vector3(-2.93f, 3.1f));
        chargePositionList.Insert(1, new Vector3(0f, 4.35f));
        chargePositionList.Insert(2, new Vector3(3.54f, 3.63f));
        chargePositionList.Insert(3, new Vector3(5.32f, 0f));
        chargePositionList.Insert(4, new Vector3(3.18f, -2.81f));
        chargePositionList.Insert(5, new Vector3(0.05f, -4.22f));
        chargePositionList.Insert(6, new Vector3(-3.49f, -3.49f));
        chargePositionList.Insert(7, new Vector3(-4.69f, 0.17f));
        float rand = UnityEngine.Random.Range(-0.15f, 0.15f);
        llStartPosition.Insert(0, new Vector3(0 + rand, 18 + rand));
        llStartPosition.Insert(1, new Vector3(18 + rand, 0 + rand));
        llStartPosition.Insert(2, new Vector3(0 + rand, -18 + rand));
        llStartPosition.Insert(3, new Vector3(-18.4f + rand, 0 + rand));
        float rand1 = UnityEngine.Random.Range(-0.15f, 0.15f);
        float a = 9.3f;
        float b = 16.1f;
        llFinishPosition.Insert(0, new Vector3(a + rand1, b + rand1));
        llFinishPosition.Insert(1, new Vector3(b + rand1, a + rand1));
        llFinishPosition.Insert(2, new Vector3(b + rand1, -a + rand1));
        llFinishPosition.Insert(3, new Vector3(a + rand1, -b + rand1));
        llFinishPosition.Insert(4, new Vector3(-a + rand1, -b + rand1));
        llFinishPosition.Insert(5, new Vector3(-b + rand1, -a + rand1));
        llFinishPosition.Insert(6, new Vector3(-b + rand1, a + rand1));
        llFinishPosition.Insert(7, new Vector3(-a + rand1, b + rand1));
    }


    protected override void Update()
    {

        if (autoToggle.isOn)
        {
            base.Update();
        }
        else
        {
            Timeline();
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed_move);
        }
    }
    private void Timeline()
    {
        switch (movecount)
        {
            case 0:
                if (timer.phaseTime > 0.1)
                {
                    movecount++;
                    targetPosition = defaultPosition;
                }
                break;
            case 1:
                if (timer.phaseTime > 9.5)
                {
                    movecount++;
                    priorityMessenger.EcPriority();
                }
                break;
            case 2:
                if (timer.phaseTime > 13.5 )
                {
                    movecount++;
                    if (!boss.innerSafe)
                    {
                        if (priority == 3)
                        {
                            targetPosition = outerTSorRPosition;
                        }
                        else
                        {
                            targetPosition = innerTSorRPosition;
                        }
                    }
                    else if (boss.innerSafe)
                    {
                        if (priority == 3)
                        {
                            targetPosition = innerTSorRPosition;
                        }
                        else
                        {
                            targetPosition = outerTSorRPosition;
                        }
                    }
                }
                break;
            case 3:
                if (timer.phaseTime > 16.3)
                {
                    movecount++;
                    targetPosition = defaultPosition;
                }
                break;
            case 7:
                if (timer.phaseTime > 44)
                {
                    movecount++;
                    targetPosition = _SVRPostion;
                }
                break;
            case 6:
                if (timer.phaseTime > 39)
                {
                    movecount++;
                    targetPosition = defaultPosition;
                    priority = 0;
                }
                break;
            case 4:
                if (timer.phaseTime > 35)
                {
                    movecount++;
                    if (!boss.innerSafe)
                    {
                        targetPosition = outerTSorRPosition;
                    }
                    else if (boss.innerSafe)
                    {
                        targetPosition = innerTSorRPosition;
                    }
                }
                break;
            case 5:
                if (timer.phaseTime > 37 )
                {
                    movecount++;
                    if (targetPosition == outerTSorRPosition)
                    {
                        targetPosition = innerTSorRPosition;
                    }
                    else if (targetPosition == innerTSorRPosition)
                    {
                        if (!this.CompareTag("MainTank"))
                        {
                            targetPosition = outerTSorRPosition;
                        }
                    }
                }
                break;
            case 8:
                if (timer.phaseTime > 47 )
                {
                    movecount++;
                    targetPosition = defaultPosition;
                }
                break;
            case 9:
                if (timer.phaseTime > 55)
                {
                    movecount++;
                    priorityMessenger.EcPriority();
                }
                break;
            case 10:
                if (timer.phaseTime > 66)
                {
                    movecount++;

                    if (boss.cloudIndex == 0)
                    {
                        if (priority == 1)
                        {
                            targetPosition = tsEcPosition1;
                        }
                        else if (priority == 2)
                        {
                            targetPosition = tsEcPosition2;
                        }
                        else { targetPosition = tsReadyPositionDown; }

                    }
                    else if (boss.cloudIndex == 1)
                    {
                        if (priority == 1)
                        {
                            targetPosition = tsEcPosition3;
                        }
                        else if (priority == 2)
                        {
                            targetPosition = tsEcPosition4;
                        }
                        else
                        {
                            targetPosition = tsReadyPositionRight;
                        }
                    }
                }
                break;
            case 11:
                if (timer.phaseTime > 70)
                {
                    movecount++;
                    if (!(priority == 1 || priority == 2))
                    {
                        targetPosition = tsSafePosition;
                    }
                    priority = 0;
                }
                break;
            case 12:
                if (timer.phaseTime > 72.3)
                {
                    movecount++;
                    priorityMessenger.NonEcPriority();
                }
                break;
            case 13:
                if (timer.phaseTime > 72.7)
                {
                    movecount++;
                    int[] nearestEchoList = boss.echoIndex;
                    Array.Sort(nearestEchoList);
                    int k = 0;
                    int j = priorityMessenger.chargeRandomSeed;
                    for (int i = 1; i < 7; i++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        if (this.priority == i)
                        {
                            targetPosition = chargePositionList[nearestEchoList[k]];
                        }
                        k++;
                    }
                }
                break;
            case 14:
                if (timer.phaseTime > 74.3)
                {
                    movecount++;
                    priority = 0;
                    priorityMessenger.EcPriority();
                    bool a = priorityMessenger.CheckOddEc();
                    if (!isMelee)
                    {
                        if ((a&&priority==7)||(!a&&priority==0))
                        {
                            targetPosition = Vector3.zero;
                        }
                        else
                        {
                            if (boss.trueEchoIndex == 2 || boss.trueEchoIndex == 6)
                            {
                                targetPosition = hcRangerPositionRight;
                            }
                            else
                            {
                                targetPosition = hcRangerPositionLeft;
                            }
                        }
                    }
                    else
                    {
                        targetPosition = defaultPosition;
                    }
                }
                break;
            case 15:
                if (timer.phaseTime > 77.5)
                {
                    movecount++;
                    targetPosition = defaultPosition;
                }
                break;
            case 16:
                if (timer.phaseTime > 93)
                {
                    movecount++;
                    if (isTank)
                    {
                        Vector3 tempVec = this.GetComponent<TankAction>().anotherTank.transform.position;
                        StartCoroutine("SwapTank", tempVec);
                    }
                }
                break;
            case 17:
                if (timer.phaseTime > 98.5)
                {
                    movecount++;
                    targetPosition = _2ndTsReadyPosition;
                }
                break;
            case 18:
                if (timer.phaseTime > 102.5)
                {
                    movecount++;
                    _2ndDSorRInnerRight = new Vector3(_2ndDSorRInnerLeft.x * -1, _2ndDSorRInnerLeft.y);
                    _2ndDSorROuterLeft = new Vector3(_2ndDSorRInnerLeft.x - 1, _2ndDSorRInnerLeft.y - 4);
                    _2ndDSorROuterRight = new Vector3(_2ndDSorRInnerLeft.x * -1 + 2, _2ndDSorRInnerRight.y - 3);
                    if (boss.cloudIndex == 0)
                    {
                        if (!boss.innerSafe)
                        {
                            targetPosition = _2ndDSorROuterLeft;
                        }
                        else if (boss.innerSafe)
                        {
                            targetPosition = _2ndDSorRInnerLeft;
                        }
                    }
                    else if (boss.cloudIndex == 1)
                    {
                        if (!boss.innerSafe)
                        {
                            targetPosition = _2ndDSorROuterRight;
                        }
                        else if (boss.innerSafe)
                        {
                            targetPosition = _2ndDSorRInnerRight;
                        }
                    }
                }
                break;
            case 19:
                if (timer.phaseTime > 106)
                {
                    movecount++;
                    if (targetPosition == _2ndDSorROuterLeft)
                    {
                        targetPosition = _2ndDSorRInnerLeft;
                    }
                    else if (targetPosition == _2ndDSorRInnerLeft)
                    {
                        targetPosition = _2ndDSorROuterLeft;
                    }
                    else if (targetPosition == _2ndDSorROuterRight)
                    {
                        targetPosition = _2ndDSorRInnerRight;
                    }
                    else if (targetPosition == _2ndDSorRInnerRight)
                    {
                        targetPosition = _2ndDSorROuterRight;
                    }
                }
                break;
            case 20:
                if (timer.phaseTime > 107.2)
                {
                    rdyForLanceLeftDown = rdyForLanceUpRight * -1;
                    movecount++;
                    if (boss.cloudIndex == 0)
                    {
                        targetPosition = rdyForLanceLeftDown;
                    }
                    else if (boss.cloudIndex == 1)
                    {
                        targetPosition = rdyForLanceUpRight;
                    }
                }
                break;
            case 21:
                if (timer.phaseTime > 111.4)
                {
                    movecount++;
                    if (targetPosition == rdyForLanceUpRight)
                    {
                        if (boss.spearIndex2 == 3 || boss.spearIndex2 == 9)
                        {
                            targetPosition = llStartPosition[0];
                            startPosIndex = 0;
                        }
                        if (boss.spearIndex2 == 0 || boss.spearIndex2 == 6)
                        {
                            targetPosition = llStartPosition[1];
                            startPosIndex = 1;
                        }
                    }
                    else if (targetPosition == rdyForLanceLeftDown)
                    {
                        if (boss.spearIndex2 == 3 || boss.spearIndex2 == 9)
                        {
                            targetPosition = llStartPosition[2];
                            startPosIndex = 2;
                        }
                        if (boss.spearIndex2 == 0 || boss.spearIndex2 == 6)
                        {
                            targetPosition = llStartPosition[3];
                            startPosIndex = 3;
                        }
                    }
                }
                break;
            case 22:
                if (timer.phaseTime > 114.2)
                {
                    switch (startPosIndex)
                    {
                        case 0:
                            if (boss.spearIndex1 == 4)
                            { targetPosition = llFinishPosition[1]; }
                            else
                            { targetPosition = llFinishPosition[6]; }
                            break;
                        case 1:
                            if (boss.spearIndex1 == 4)
                            { targetPosition = llFinishPosition[3]; }
                            else
                            { targetPosition = llFinishPosition[0]; }
                            break;
                        case 2:
                            if (boss.spearIndex1 == 4)
                            { targetPosition = llFinishPosition[5]; }
                            else
                            { targetPosition = llFinishPosition[2]; }
                            break;
                        case 3:
                            if (boss.spearIndex1 == 4)
                            { targetPosition = llFinishPosition[7]; }
                            else { targetPosition = llFinishPosition[4]; }
                            break;
                        default:
                            break;
                    }
                }
                break;
            default:
                break;
        }
    }

    IEnumerator SwapTank(Vector3 vector3)
    {
        yield return new WaitForSeconds(1f);
        defaultPosition = vector3;
        targetPosition = defaultPosition;
    }
}
