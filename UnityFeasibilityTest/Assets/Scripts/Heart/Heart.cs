using System;
using UnityEngine.UI;

public class Heart
{
    private const float FillPerHeartPieces = 0.25f;
    public static readonly int HeartPiecesPerHeart = 4;
    private Image _image;

    public Heart(Image image)
    {
        this._image = image;
    }

    public int CurrentNumberOfHeartPieces
    {
        get { return (int)(_image.fillAmount * HeartPiecesPerHeart); }
    }

    public void Replenish(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0)
            throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberOfHeartPieces");

        _image.fillAmount += numberOfHeartPieces * FillPerHeartPieces;
    }

    public void Deplete(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0)
            throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberOfHeartPieces");

        _image.fillAmount -= numberOfHeartPieces * FillPerHeartPieces;
    }
}
