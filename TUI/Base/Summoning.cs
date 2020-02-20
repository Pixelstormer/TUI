﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaUI.Base
{
    internal class Summoning
    {
        public VisualObject Summoned { get; }
        public bool RemoveOnUnsummon { get; }
        public int OldX { get; }
        public int OldY { get; }
        public int OldWidth { get; }
        public int OldHeight { get; }
        public Summoning(VisualObject node, bool removeOnUnsummon, int oldX, int oldY, int oldWidth, int oldHeight)
        {
            Summoned = node;
            RemoveOnUnsummon = removeOnUnsummon;
            OldX = oldX;
            OldY = oldY;
            OldWidth = oldWidth;
            OldHeight = oldHeight;
        }
    }
}
