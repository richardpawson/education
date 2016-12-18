using System.Collections.Generic;

namespace PredatorPrey.Model
{
    public interface ISetUp
    {
        Landscape Landscape { get; }
        List<Warren> Warrens { get; }
        List<Fox> Foxes { get; }
        int Variability { get; }
    }
}
