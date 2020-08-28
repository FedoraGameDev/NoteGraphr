namespace FedoraDev.NoteGraphr.Core.GraphNode
{
    public class TextNode : IGraphNode
    {
        public string Content { get; private set; } = "";
        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;

        public void SetContent(string newContent)
        {
            Content = newContent;
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
    }
}
