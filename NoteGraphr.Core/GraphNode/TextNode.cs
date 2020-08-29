using System;

namespace NoteGraphr.Core.GraphNode
{
    public class TextNode : GraphNodeBase
    {
        public string Content { get; private set; } = "";

        public TextNode() : base() { }

        public TextNode(string content) : base()
        {
            Content = content;
        }

        public void SetContent(string newContent)
        {
            Content = newContent;
        }
    }
}
