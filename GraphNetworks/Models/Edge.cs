using System.Diagnostics.CodeAnalysis;

namespace GraphNetworks.Models
{
    internal class Edge
    {
        [SetsRequiredMembers]
        public Edge(Vertex source, Vertex destination)
        {
            Source = source;
            Destination = destination;
        }


        public required Vertex Source { get; set; }
        public required Vertex Destination { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
                return false;

            if (obj is not Edge e)
                return false;

            return e.Source.Equals(Source) && e.Destination.Equals(Destination);
        }

        // override object.GetHashCode
        public override int GetHashCode() => (Source, Destination).GetHashCode();
    }
}
