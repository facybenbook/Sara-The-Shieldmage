﻿using System;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

[Serializable]
public class NemesisParty
{
    #region Variables / Properties

    public string NemesisPartyName;
    public string CurrentLocation;
    public List<NemesisEnemy> NemesisPartyMembers;
    public NemesisProgression NemesisStrategy;

    public float LastStepStarted = 0.0f;
    public float ShortDuration = 5.0f;
    public float MediumDuration = 10.0f;
    public float LongDuration = 15.0f;

    public NemesisObjective CurrentObjective
    {
        get { return NemesisStrategy.CurrentObjective; }
    }

    public float CurrentObjectiveDuration
    {
        get
        {
            NemesisObjectiveDuration duration = CurrentObjective.Duration;
            switch(duration)
            {
                case NemesisObjectiveDuration.Short:
                    return ShortDuration;

                case NemesisObjectiveDuration.Medium:
                    return MediumDuration;

                case NemesisObjectiveDuration.Long:
                    return LongDuration;

                default:
                    throw new InvalidOperationException("Unexpected duration: " + duration);
            }
        }
    }

    #endregion Variables / Properties

    #region Methods

    public JSONClass ExportState()
    {
        JSONClass state = new JSONClass();

        state["NemesisPartyName"] = new JSONData(NemesisPartyName);
        state["CurrentLocation"] = new JSONData(CurrentLocation);

        state["NemesisPartyMembers"] = new JSONArray();
        for (int i = 0; i < NemesisPartyMembers.Count; i++)
        {
            NemesisEnemy current = NemesisPartyMembers[i];
            state["NemesisPartyMembers"].Add(current.ExportState());
        }

        state["NemesisProgression"] = NemesisStrategy.ExportState();

        state["LastStepStarted"] = new JSONData(LastStepStarted);
        state["ShortDuration"] = new JSONData(ShortDuration);
        state["MediumDuration"] = new JSONData(MediumDuration);
        state["LongDuration"] = new JSONData(LongDuration);

        return state;
    }

    public bool IsPlanStepComplete()
    {
        return Time.time > LastStepStarted + CurrentObjectiveDuration;
    }

    public NemesisContingency ProceedToPlanOutcome(NemesisPlanOutcome outcome)
    {
        var contingencyResult = NemesisStrategy.ProceedToPlanOutcome(outcome);
        LastStepStarted = Time.time;
        return contingencyResult;
    }

    #endregion Methods
}
