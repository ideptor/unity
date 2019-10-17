using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Tests.Infrastructure
{
    public class ImageBuilder
    {
        private int _fillAmount;

        public ImageBuilder(int fillAmount)
        {
            _fillAmount = fillAmount;
        }

        public ImageBuilder() : this(0)
        {

        }

        public ImageBuilder WithFillAmount(int fillAmount)
        {
            _fillAmount = fillAmount;
            return this;
        }
        public Image Build()
        {
            var image = new GameObject().AddComponent<Image>();
            image.fillAmount = _fillAmount;
            return image;
        }

        public static implicit operator Image(ImageBuilder imageBuilder)
        {
            return imageBuilder.Build();
        }
    }

}
