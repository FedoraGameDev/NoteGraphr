using FedoraDev.NoteGraphr.Core.IDTrackers;
using System;

namespace FedoraDev.NoteGraphr.Core.GraphNode
{
    public abstract class GraphNodeBase
    {
        public uint ID { get; private set; }
        public int Width { get; private set; } = 4;
        public int Height { get; private set; } = 1;
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;

        public GraphNodeBase()
        {
            ID = IDTracker.Add(this);
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
