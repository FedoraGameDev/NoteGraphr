﻿using NoteGraphr.Core.Graph;
using NoteGraphr.Core.UniqueID;
using System;

namespace NoteGraphr.Core.GraphNode
{
    public abstract class GraphNodeBase : IGraphable
    {
        public uint ID { get; }
        public int Width { get; private set; } = 4;
        public int Height { get; private set; } = 1;
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;

        public GraphNodeBase()
        {
            ID = UID.AddAndGetID(this);
        }

        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public void Grow(int deltaWidth, int deltaHeight)
        {
            Width = Math.Max(1, Width + deltaWidth);
            Height = Math.Max(1, Height + deltaHeight);
        }
    }
}
