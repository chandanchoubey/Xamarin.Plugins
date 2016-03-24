﻿using System;
using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.UWP;
using Plugin.Iconize.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using TextBlock = Windows.UI.Xaml.Controls.TextBlock;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]
namespace FormsPlugin.Iconize.UWP
{
    /// <summary>
    /// Defines the <see cref="IconButtonRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.UWP.ButtonRenderer" />
    public class IconButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Button}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            UpdateText();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if ((e.PropertyName == nameof(IconButton.FontSize) ||
                (e.PropertyName == nameof(IconButton.Text)) ||
                (e.PropertyName == nameof(IconButton.TextColor))))
            {
                UpdateText();
            }
        }

        /// <summary>
        /// Updates the text.
        /// </summary>
        private void UpdateText()
        {
            if (String.IsNullOrEmpty(Element.Text) == false)
            {
                var content = new TextBlock();
                content.Inlines.Add(ParsingUtil.Parse(Plugin.Iconize.Iconize.Modules, Element.Text, Element.FontSize));
                Control.Content = content;
            }
        }
    }
}