﻿using UnityEngine;
using System.Collections;

public class ShopMainPresenter : UGUIPresenterBase
{
    #region Variables / Properties

    private ShopController _controller;

    #endregion Variables / Properties

    #region Hooks

    public override void Start()
    {
        base.Start();
        _controller = ShopController.Instance;
    }

    public void BuyItems()
    {
        _controller.PresentGrid(true);
    }

    public void SellItems()
    {
        _controller.PresentGrid(false);
    }

    public void StopShopping()
    {
        _controller.StopShopping();
    }

    #endregion Hooks

    #region Methods

    #endregion Methods
}
