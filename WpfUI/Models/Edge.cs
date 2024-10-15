using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models.Base;

namespace WpfUI.Models
{
    public class Edge(string name, Vertex firstVertex, Vertex secondVertex) : INPC
    {
        #region Name

        private string _Name = name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        #endregion

        #region FirstVertex

        private Vertex _FirstVertex = firstVertex;
        public Vertex FirstVertex
        {
            get => _FirstVertex;
            set => Set(ref _FirstVertex, value);
        }

        #endregion

        #region SecondVertex

        private Vertex _SecondVertex = secondVertex;
        public Vertex SecondVertex
        {
            get => _SecondVertex;
            set => Set(ref _SecondVertex, value);
        }

        #endregion
        
        public static bool operator ==(Edge left, Edge right)
            => left.Name == right.Name
            && left.FirstVertex == right.FirstVertex
            && left.SecondVertex == right.SecondVertex;
        public static bool operator !=(Edge left, Edge right)
            => !( left == right );

        public override bool Equals(object? obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
