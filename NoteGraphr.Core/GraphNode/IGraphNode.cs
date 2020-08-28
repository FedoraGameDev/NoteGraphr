namespace FedoraDev.NoteGraphr.Core.GraphNode
{
    public interface IGraphNode
    {
        string Content { get; }
        int Width { get; }
        int Height { get; }
        int X { get; }
        int Y { get; }

        void SetContent(string newContent);
        void SetSize(int width, int height);
        void SetPosition(int x, int y);
    }
}
