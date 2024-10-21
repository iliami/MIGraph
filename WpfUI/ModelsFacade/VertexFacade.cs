using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models;
using WpfUI.ModelsFacade.Base;

namespace WpfUI.ModelsFacade
{
    public class VertexFacade(Vertex vertex) : INPC
    {
        Vertex _Vertex = vertex;

        public string Name
        {
            get => _Vertex.Name;
            set
            {
                _Vertex.Name = value;
                OnPropertyChanged();
            }
        }
    }
}
