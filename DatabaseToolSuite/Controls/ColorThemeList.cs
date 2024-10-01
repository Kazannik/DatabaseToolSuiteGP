﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace DatabaseToolSuite.Controls
{
    public partial class ColorThemeList : Component
    {
        ColorTheme defaultTheme;
        List<ColorTheme> themes;

        public ColorThemeList()
        {
            themes = new List<ColorTheme>();
            defaultTheme = new ColorThemeOffice2003(this);
            themes.Add(defaultTheme);
            InitializeComponent();
        }
        
        public ColorTheme this[int index]
        {
            get { return this.themes[index]; }
        }

        public ColorTheme Default
        {
            get { return this.defaultTheme; }
        }
    }

    public enum ThemeType
    {
        Office2003,
        Office2007
    }

    public class ColorTheme
    {
        ColorThemeList control;
        public ColorTheme(ColorThemeList control)
        {
            this.control = control;
        }

        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public Color ForeColorSelected { get; set; }
        public Color BackColorSelected { get; set; }
        public Color ColorHoveringTop { get; set; }
        public Color ColorHoveringBottom { get; set; }
        public Color ColorSelectedTop { get; set; }
        public Color ColorSelectedBottom { get; set; }
        public Color ColorSelectedAndHoveringTop { get; set; }
        public Color ColorSelectedAndHoveringBottom { get; set; }
        public Color ColorPassiveTop { get; set; }
        public Color ColorPassiveBottom { get; set; }
    }

    public class ColorThemeOffice2003 : ColorTheme
    {
        public ColorThemeOffice2003(ColorThemeList control) : base(control)
        {
            ColorSelectedAndHoveringTop = Color.FromArgb(232, 127, 8);
            ColorSelectedAndHoveringBottom = Color.FromArgb(247, 218, 124);
            ColorHoveringTop = Color.FromArgb(255, 255, 220);
            ColorHoveringBottom = Color.FromArgb(247, 192, 91);
            ColorSelectedTop = Color.FromArgb(247, 218, 124);
            ColorSelectedBottom = Color.FromArgb(232, 127, 8);
            ColorPassiveTop = Color.FromArgb(203, 225, 252);
            ColorPassiveBottom = Color.FromArgb(125, 166, 223);
        }

        public new Color ForeColor { get; private set; }
        public new Color BackColor { get; private set; }
        public new Color ForeColorSelected { get; private set; }
        public new Color BackColorSelected { get; private set; }
        public new Color ColorHoveringTop { get; private set; }
        public new Color ColorHoveringBottom { get; private set; }
        public new Color ColorSelectedTop { get; private set; }
        public new Color ColorSelectedBottom { get; private set; }
        public new Color ColorSelectedAndHoveringTop { get; private set; }
        public new Color ColorSelectedAndHoveringBottom { get; private set; }
        public new Color ColorPassiveTop { get; private set; }
        public new Color ColorPassiveBottom { get; private set; }
    }
}
