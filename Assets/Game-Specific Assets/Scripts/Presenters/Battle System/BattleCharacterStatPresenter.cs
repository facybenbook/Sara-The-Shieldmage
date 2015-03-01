﻿using UnityEngine;
using UnityEngine.UI;

public class BattleCharacterStatPresenter : UGUIPresenterBase
{
    #region Variables / Properties

    public Image Thumbnail;
    public Image HealthGauge;
    public Image ATBGauge;

    public int MaxHealthGaugeSize = 100;
    public int MaxATBGaugeSize = 100;

    public CombatEntity Character;

    private const float gaugeTheta = 0.01f;

    #endregion Variables / Properties

    #region Hooks

    public void BindCharacter(CombatEntity character)
    {
        Character = character;
        // TODO: Associate character thumbnail...
    }

    public void UpdateATB()
    {
        int ATB = Character.GetStatByName("ATB").Value;
        int MaxATB = Character.GetStatByName("Max ATB").Value;

        float gaugeSize = ((float) ATB / MaxATB);
        if (gaugeSize - 1.0f > gaugeTheta)
            gaugeSize = 1.0f;

        gaugeSize *= MaxHealthGaugeSize;

        ATBGauge.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, gaugeSize);
        DebugMessage("Player " + Character.Name + "'s ATB bar should measure " + gaugeSize + "px. wide.");
    }

    public void UpdateHealth()
    {
        int HP = Character.Health.HP;
        int MaxHP = Character.Health.MaxHP;

        float gaugeSize = ((float) HP / MaxHP);
        if (gaugeSize - 1.0f > gaugeTheta)
            gaugeSize = 1.0f;

        gaugeSize *= MaxHealthGaugeSize;

        HealthGauge.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, gaugeSize);
        DebugMessage("Player " + Character.Name + "'s HP bar should measure " + gaugeSize + "px. wide.");
    }

    #endregion Hooks

    #region Methods

    #endregion Methods
}
